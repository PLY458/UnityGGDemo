using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

/// <summary>
/// UI常用工具集
/// </summary>
public static class UITool
{
    //需要获取的场景上的画布文件
    private static GameObject m_CanvasObj = null; 

    //释放获取的画布文件
    public static void ReleaseCanvas()
    {
        m_CanvasObj = null;
    }

    /// <summary>
    /// 根据UI名找到画布下对应的UI组件
    /// </summary>
    /// <param name="UIName"></param>
    /// <returns></returns>
    public static GameObject FindUIGameObject(string UIName)
    {
        if (m_CanvasObj == null)
            m_CanvasObj = UnityObjectTool.FindGameObject("Canvas");
        if (m_CanvasObj == null)
            return null;
        return UnityObjectTool.FindChildGameObject(m_CanvasObj, UIName);
    }

    /// <summary>
    /// 根据组件类别寻找子UI组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ParentObj"></param>
    /// <param name="UIName"></param>
    /// <returns></returns>
    public static T GetUIComponent<T>(GameObject ParentObj, string UIName) where T : UnityEngine.Component
    {
        // 找出子物件 
        GameObject ChildObj = UnityObjectTool.FindChildGameObject(ParentObj, UIName);
        if (ChildObj == null)
            return null;

        T tempObj = ChildObj.GetComponent<T>();
        if (tempObj == null)
        {
            Debug.LogWarning("子元件[" + UIName + "]不是[" + typeof(T) + "]类型");
            return null;
        }
        return tempObj;
    }

    /// <summary>
    /// 获得对应名称的按钮组件
    /// </summary>
    /// <param name="BtnName"></param>
    /// <returns></returns>
    public static Button GetButton(string BtnName)
    {
        // 取得Canvas
        GameObject UIRoot = GameObject.Find("Canvas");
        if (UIRoot == null)
        {
            Debug.LogWarning("場景上沒有UI Canvas");
            return null;
        }

        // 找出對應的Button
        Transform[] allChildren = UIRoot.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == BtnName)
            {
                Button tmpBtn = child.gameObject.GetComponent<Button>();
                if (tmpBtn == null)
                    Debug.LogWarning("UI原件[" + BtnName + "]不是Button");
                return tmpBtn;
            }
        }

        Debug.LogWarning("UI Canvas中沒有Button[" + BtnName + "]存在");
        return null;
    }

    /// <summary>
    /// 直接获取对应名称UI组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="UIName"></param>
    /// <returns></returns>
    public static T GetUIComponent<T>(string UIName) where T : UnityEngine.Component
    {
        // 取得Canvas
        GameObject UIRoot = GameObject.Find("Canvas");
        if (UIRoot == null)
        {
            Debug.LogWarning("場景上沒有UI Canvas");
            return null;
        }
        return GetUIComponent<T>(UIRoot, UIName);
    }
}
