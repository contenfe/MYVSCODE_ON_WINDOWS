using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/**
 * @Description:
         序列化：将对象转换成二进制
         反序列化：将二进制转换成对象

 * @param {*}
 * @return {*}
 */
[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{
    [NonSerialized] // 反序列化后要打标签
    public UIPanelType panelType;
    public string panelTypeString;
    public string path;

    /**
     * @Description: 在反序列化完成之后调用这个方法
     */
    public void OnAfterDeserialize()
    {
        // 强转，将string 类型转换成 对应的 Enum类型
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        panelType = type;// 将强转后的枚举保存到反序列化
    }

    /**
     * @Description: 在序列化完成之前调用这个方法
     */
    public void OnBeforeSerialize()
    {

    }
}

class UIPanelTypeJson
{
    public List<UIPanelInfo> infoList;

}