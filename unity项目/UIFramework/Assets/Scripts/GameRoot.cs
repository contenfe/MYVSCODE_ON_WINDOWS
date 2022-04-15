/*
 * @Author: 秦武胜
 * @Date: 2022-04-14 15:26:53
 * @LastEditTime: 2022-04-14 19:10:50
 * @LastEditors: 秦武胜
 * @Description: 挂在在任一物体上
 * @FilePath: \UIFramework\Assets\Scripts\GameRoot.cs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Description: 负责启动这个框架的, 框架启动器
 */
public class GameRoot : MonoBehaviour
{

    void Start()
    {
        UIManager.Instance.PushPanel(UIPanelType.MainMenu);
    }


    void Update()
    {

    }
}
