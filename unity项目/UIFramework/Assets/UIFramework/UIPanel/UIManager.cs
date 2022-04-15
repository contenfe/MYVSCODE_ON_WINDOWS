/*
 * @Author: 秦武胜
 * @Date: 2022-04-14 14:35:46
 * @LastEditTime: 2022-04-15 15:16:18
 * @LastEditors: 秦武胜
 * @Description:
                解析保存所有的面板存储路径信息
                创建并保存所有面板实例化后的游戏物体
                管理面板
                    1.预制体
                    2.实例化
                    3.显示出来的面板
 * @FilePath: \MYVSCODE_ON_WINDOWS\unity项目\UIFramework\Assets\UIFramework\UIPanel\UIManager.cs
 */
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * @Description: 解析json文件
                FromJson:把json对象转换成一个对象
                ToJson：把一个对象转换成json信息

 */
public class UIManager
{
    private Dictionary<UIPanelType, string> panelPathDict;// 存储所有面板预制体的路径的字典

    private Dictionary<UIPanelType, BasePanel> panelDict;// 存储所有事例化的面板basepanel的字典

    private Stack<BasePanel> panelStack;// 管理显示出来的面板

    private Transform canvasTransform;
    public Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                GameObject.Instantiate(Resources.Load<GameObject>("UIPanel/Canvas")); // 写死，不可能出现两个
            }
            return canvasTransform;
        }
    }
    void ParseUIPanelTypeJosn()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();


        // 加载json 文件
        TextAsset textAsset = Resources.Load<TextAsset>("TextInfo/UIPanelType");
        // 解析Json
        UIPanelTypeJson uIPanelInfo = JsonUtility.FromJson<UIPanelTypeJson>(textAsset.text);

        foreach (var item in uIPanelInfo.infoList)
        {
            panelPathDict.Add(item.panelType, item.path);
        }
    }

    // 設置成单例模式
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }

            return instance;
        }
    }
    private UIManager()
    {
        ParseUIPanelTypeJosn();
    }

    #region 測試用
    /**
     * @Description: 测试json是否解析成功
     */
    public void Test()
    {
        string path;

        panelPathDict.TryGetValue(UIPanelType.MainMenu, out path);
        Debug.Log(path);
    }
    #endregion 

    /**
     * @Description: 获取面板,事例化游戏UI面板
     * @param 获取面板类型
     * @return 
     */
    private BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        BasePanel basePanel;
        panelDict.TryGetValue(panelType, out basePanel);

        // 该类型面板没有实例化
        if (basePanel == null)
        {
            string path;
            panelPathDict.TryGetValue(panelType, out path); // 根据面板类型去获取其对应的路径
            if (path != null) // 说明路径存在，可以事例化
            {

                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(path));
                go.transform.SetParent(canvasTransform, false); // 不需要保持自己的世界坐标
                AddScriptsComponent(panelType, go); // 动态挂载物体
                panelDict.Add(panelType, go.GetComponent<BasePanel>());
                return go.GetComponent<BasePanel>();
            }
        }

        Debug.Log("该面板已经实例化");
        return basePanel;

    }


    /**
     * @Description: 给事例化出来的面板挂载脚本
     * @param {挂载类型，挂载物体}
     * @return {null}
     */
    void AddScriptsComponent(UIPanelType iPanelType, GameObject instpanel)
    {
        //用来实现在一个被激活的界面，不能再点击其他按钮，除非这个窗口关闭
        instpanel.AddComponent<CanvasGroup>();
        // 第一种动态的挂载脚本
        // 有缺陷，如果有100多面板怎么选择,如果物体挂了两次脚本会响应两次，解决：使用泛型
        switch (iPanelType)
        {
            case UIPanelType.MainMenu:
                instpanel.AddComponent<MainMenuPanel>();
                break;
            case UIPanelType.Bag:
                instpanel.AddComponent<BagPanel>();
                break;
            case UIPanelType.ItemMessage:
                instpanel.AddComponent<ItemMessagePanel>();
                break;
            case UIPanelType.Shop:
                instpanel.AddComponent<ShopPanel>();
                break;
            case UIPanelType.Skill:
                instpanel.AddComponent<SkillPanel>();
                break;
            case UIPanelType.System:
                instpanel.AddComponent<SystemPanel>();
                break;
            case UIPanelType.Task:
                instpanel.AddComponent<TaskPanel>();
                break;


        }

        return; // 无异议，只是将下面的方法隔离开来

        // 第三种动态挂载脚本
        // 反射 ，.NET中获得运行时类型信息的方式 Assembly module, CLASS net 类型 ，要慎用，破坏了程序的清晰性
        string panelTypeStr = Enum.GetName(iPanelType.GetType(), iPanelType); // 获取枚举所对应的字符串
        string scriptsName = panelTypeStr + "Panel";
        Type scrptsType = Type.GetType(scriptsName);
        if (!instpanel.GetComponent(scrptsType)) // 防止预制体上有脚本了还挂一个
        {
            instpanel.AddComponent(scrptsType);

        }



    }


    // 泛型 即通过参数化类型来实现在同一份代码上操作多种数据类型
    private T GetAndAddComponent<T>(GameObject instPanel) where T : Component // 限定类型
    {
        // 第二种动态挂载脚本
        if (!instPanel.GetComponent<T>()) // 获取游戏物体上对应的T主件
        {
            instPanel.AddComponent<T>(); // 给其挂载脚本
        }
        return instPanel.GetComponent<T>(); // 返回物体上的T主件
    }

    /**
     * @Description: 存储面板
     * @param {面板类型}
     * @return {}
     */
    public void PushPanel(UIPanelType panelType)
    {
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        if (panelStack.Count > 0)
        {
            BasePanel basePanel1 = panelStack.Peek();// 获取栈顶的元素；-> 当前已经打开的元素
            basePanel1.OnPause();

        }
        BasePanel basePanel = GetPanel(panelType);
        basePanel.OnEnter();
        panelStack.Push(basePanel);
    }

    #region 测试

    #endregion

}
