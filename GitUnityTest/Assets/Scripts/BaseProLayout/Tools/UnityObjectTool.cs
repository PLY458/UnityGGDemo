using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


/// <summary>
/// Unity有关于GameObject的常用操作集工具方法(可能有用)
/// </summary>
public static class UnityObjectTool
{
    /// <summary>
    /// 将子物体附加在父物体上
    /// </summary>
    /// <param name="ParentObj"></param>
    /// <param name="ChildObj"></param>
    /// <param name="Pos"></param>
    public static void Attach(GameObject ParentObj, GameObject ChildObj, Vector3 Pos)
    {
        ChildObj.transform.parent = ParentObj.transform;
        ChildObj.transform.localPosition = Pos;
    }

    /// <summary>
    /// 检测父物体是否已带有子物体，有则
    /// </summary>
    /// <param name="ParentObj"></param>
    /// <param name="ChildObj"></param>
    /// <param name="RefPointName">挂载点物体名</param>
    /// <param name="Pos"></param>
    public static void AttachToRefPos(GameObject ParentObj, GameObject ChildObj, string RefPointName, Vector3 Pos)
    {
        // 开始寻找是否有同名的子物体
        bool bFinded = false;
        Transform[] allChildren = ParentObj.transform.GetComponentsInChildren<Transform>();
        // 临时RectTransform
        Transform RefTransform = null;
        foreach (Transform child in allChildren)
        {
            if (child.name == RefPointName)
            {
                if (bFinded == true)
                {
                    Debug.LogWarning("物件[" + ParentObj.transform.name + "]內有挂载两个以上的[" + RefPointName + "]");
                    continue;
                }
                bFinded = true;
                RefTransform = child;
            }
        }

        //  是否找到
        if (bFinded == false)
        {
            Debug.LogWarning("物件[" + ParentObj.transform.name + "]內沒有參考點[" + RefPointName + "]");
            Attach(ParentObj, ChildObj, Pos);
            return;
        }

        //引入的新物体变为为同名物体的子物体
        ChildObj.transform.parent = RefTransform;
        //进行新物体重定位操作
        ChildObj.transform.localPosition = Pos;
        ChildObj.transform.localScale = Vector3.one;
        ChildObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    
    /// <summary>
    /// 在场景中搜索物体
    /// </summary>
    /// <param name="GameObjectName"></param>
    /// <returns></returns>
    public static GameObject FindGameObject(string GameObjectName)
    {
        // 找出對應的GameObject
        GameObject pTmpGameObj = GameObject.Find(GameObjectName);
        if (pTmpGameObj == null)
        {
            Debug.LogWarning("场景中找不到GameObject[" + GameObjectName + "]");
            return null;
        }
        return pTmpGameObj;
    }

    /// <summary>
    /// 寻找父物体上的子物体
    /// </summary>
    /// <param name="ParentObj"></param>
    /// <param name="ChildObjName"></param>
    /// <returns></returns>
    public static GameObject FindChildGameObject(GameObject ParentObj, string ChildObjName)
    {
        if (ParentObj == null)
        {
            Debug.LogError("场景中找不到[" + ChildObjName + "]的父物体");
            return null;
        }
        //临时父物体坐标数据
        Transform pGameObjectTF = null; //= Container.transform.FindChild(gameobjectName);											

        // 是不是Container本身
        if (ParentObj.name == ChildObjName)
            pGameObjectTF = ParentObj.transform;
        else
        {
            // 找出所有子元件						
            Transform[] allChildren = ParentObj.transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == ChildObjName)
                {
                    if (pGameObjectTF == null)
                        pGameObjectTF = child;
                    else
                        Debug.LogWarning("父物体[" + ParentObj.name + "]下找出重覆的元件名稱[" + ChildObjName + "]");
                }
            }
        }

        // 都沒有找到
        if (pGameObjectTF == null)
        {
            Debug.LogError("元件[" + ParentObj.name + "]找不到子元件[" + ChildObjName + "]");
            return null;
        }

        return pGameObjectTF.gameObject;
    }
}
