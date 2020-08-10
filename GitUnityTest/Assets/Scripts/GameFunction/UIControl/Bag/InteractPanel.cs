using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractPanel : UIBasePanel, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            //讲拖进来的UI组件化作对应的节点
            
            Debug.Log("拖入成功：" + eventData.pointerDrag);
        }
    }

    public void AddInteractSlot()
    {
        ResourcesMgr.GetInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
        {

        }
    }
}
