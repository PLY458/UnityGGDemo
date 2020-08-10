using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractSlot : UIBasePanel, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform local_RectTrans;
    private CanvasGroup local_CanGroup;

    public void InitInfo()
    {
        //载入图片

        //GetControl<Image>("imgSlot").sprite = ResourcesMgr.GetInstance().Load<Sprite>("Icon/Ball");

        local_RectTrans = GetComponent<RectTransform>();
        local_CanGroup = GetComponent<CanvasGroup>();
    }

    public override void HideMe()
    {
        base.HideMe();
        this.gameObject.SetActive(false);
    }

    public override void ShowMe()
    {
        base.HideMe();
        this.gameObject.SetActive(true);
    }
    

    //开始拖拽时透明度调暗，射线判定取消
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        local_CanGroup.alpha = .6f;
        local_CanGroup.blocksRaycasts = false;
    }

    //结束拖拽恢复各项属性
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        local_CanGroup.alpha = 1f;
        local_CanGroup.blocksRaycasts = true;
    }

    //鼠标拖动过程中同时转变位移
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        local_RectTrans.anchoredPosition += eventData.delta;
    }

}
