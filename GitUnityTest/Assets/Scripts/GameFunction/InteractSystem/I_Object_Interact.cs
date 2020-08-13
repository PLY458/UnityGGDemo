using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// 互动游戏物体接口
/// </summary>
public abstract class I_Object_Interact
{ 
    //需要控制的各种组件
    private I_TipUI_Interact m_TipUI = null;
    protected GameObject m_InteractObject = null;
    protected MeshRenderer m_MeshRend = null;

    public void SetTipUI(I_TipUI_Interact TipUI)
    {
        if (m_TipUI != null)
            m_TipUI.Release();
        m_TipUI = TipUI;

        //设定UI拥有者
        m_TipUI.SetOwner(this);

    }

    public I_TipUI_Interact GetTipUI()
    {
        return m_TipUI;
    }

    public void SetMeshRender()
    {
        m_MeshRend = UnityTool.FindChildGameObjec
    }

    #region 交互物体操作
    /// <summary>
    /// 进行绑定UI预制体销毁
    /// </summary>
    public void Release()
    {
        if (m_InteractObject != null)
            GameObject.Destroy(m_InteractObject);
    }

    /// <summary>
    /// 设定绑定的UI
    /// </summary>
    /// <param name="theUICompent"></param>
    public void SetGameObject(GameObject theInteractObject)
    {
        m_InteractObject = theInteractObject;
    }

    /// <summary>
    /// 得到绑定的UI
    /// </summary>
    /// <returns></returns>
    public GameObject GetObjectCompent()
    {
        return m_InteractObject;
    }

    #endregion
}
