using System.Threading.Tasks;
/*
 * @Author: 秦武胜
 * @Date: 2022-04-14 16:23:14
 * @LastEditTime: 2022-04-14 19:59:17
 * @LastEditors: 秦武胜
 * @Description: 
 * @FilePath: \UIFramework\Assets\Scripts\MainMenuPanel.cs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuPanel : BasePanel
{

    private Button taskBtn;
    private Button bagBtn;
    private Button skillBtn;
    private Button systemBtn;
    private Button shopBtn;
    private Button itemMessageBtn;

    private CanvasGroup canvasGroup;

    void Start()
    {
        taskBtn = transform.Find("FunctionBar/TaskBtn").GetComponent<Button>();
        bagBtn = transform.Find("FunctionBar/BagBtn").GetComponent<Button>();
        skillBtn = transform.Find("FunctionBar/SkillBtn").GetComponent<Button>();
        systemBtn = transform.Find("FunctionBar/SystemBtn").GetComponent<Button>();
        shopBtn = transform.Find("FunctionBar/ShopBtn").GetComponent<Button>();
        // itemMessageBtn = transform.Find("FunctionBar/itemMessageBtn").GetComponent<Button>();

        taskBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Task));
        bagBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Bag));
        skillBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Skill));
        systemBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.System));
        shopBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Shop));
        // taskBtn.onClick.AddListener(OncliclkTaskBtn);

        canvasGroup = this.GetComponent<CanvasGroup>();

    }

    public override void OnPause()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public override void OnEnter()
    {
        // 手动调用 Start 系统调用
        taskBtn = transform.Find("FunctionBar/TaskBtn").GetComponent<Button>();
        bagBtn = transform.Find("FunctionBar/BagBtn").GetComponent<Button>();
        skillBtn = transform.Find("FunctionBar/SkillBtn").GetComponent<Button>();
        systemBtn = transform.Find("FunctionBar/SystemBtn").GetComponent<Button>();
        shopBtn = transform.Find("FunctionBar/ShopBtn").GetComponent<Button>();
        // itemMessageBtn = transform.Find("FunctionBar/itemMessageBtn").GetComponent<Button>();

        taskBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Task));
        bagBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Bag));
        skillBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Skill));
        systemBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.System));
        shopBtn.onClick.AddListener(() => OnClickBtn(UIPanelType.Shop));
        // taskBtn.onClick.AddListener(OncliclkTaskBtn);

        canvasGroup = this.GetComponent<CanvasGroup>();

    }

    public override void OnExit()
    {

    }

    public override void OnResume()
    {
        canvasGroup.blocksRaycasts = true;
    }

    void OnClickBtn(UIPanelType panelType)
    {
        UIManager.Instance.PushPanel(panelType);
    }
    #region 按钮点击事件

    private void OncliclkSystemBtn()
    {
        UIManager.Instance.PushPanel(UIPanelType.System);
    }

    private void OncliclkSkillBtn()
    {
        UIManager.Instance.PushPanel(UIPanelType.Skill);
    }

    private void OncliclkBagBtn()
    {
        UIManager.Instance.PushPanel(UIPanelType.Bag);
    }

    private void OncliclkShopBtn()
    {
        UIManager.Instance.PushPanel(UIPanelType.Shop);
    }

    private void OncliclkTaskBtn()
    {
        UIManager.Instance.PushPanel(UIPanelType.Task);
    }

    #endregion
}
