using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 格子对象
/// </summary>
public class InventorySlot : UIBasePanel
{
    private ItemInfo itemInfo;

    //可考虑先定义UI组件的名称

    private void Start()
    {
        
    }

    /// <summary>
    /// 设置事件监听器：Unity自带
    /// </summary>
    private void SetEventTrigger()
    {
        //初始化EventTrigger组件
        EventTrigger trigger = GetControl<Image>("itemIcon").gameObject.AddComponent<EventTrigger>();
        //声明事件的类型，ID以及添加到回调监听器中
        //鼠标进入
        EventTrigger.Entry enter = new EventTrigger.Entry();
        enter.eventID = EventTriggerType.PointerEnter;
        enter.callback.AddListener(EnterInventorySlot);
        trigger.triggers.Add(enter);

        //鼠标移除
        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerEnter;
        exit.callback.AddListener(ExitInventorySlot);
        trigger.triggers.Add(exit);
    }

    #region EeventTrigger添加的事件方法
    private void EnterInventorySlot(BaseEventData data)
    {
        Debug.Log("in");
        //显示提示面板
        UIManagercs.GetInstance().showPanelOnLayer<InteractSlot>("TipsPanel", E_UI_Layer.Top, (tipspanel) =>
        {
            //异步加载结束后 去设置位置 设置信息
            tipspanel.transform.position = GetControl<Image>("itemIcon").transform.position;
        });
    }

    private void ExitInventorySlot(BaseEventData data)
    {
        Debug.Log("out");
    }
    #endregion

    /// <summary>
    /// 根据道具信息 初始化 格子
    /// </summary>
    /// <param name="info"></param>
    public void InitInfo(ItemInfo info)
    {
        this.itemInfo = info;
        //根据道具信息的数据 来更新格子对象
        Item itemData = GameDataMgr.GetInstance().GetItemInfo(info.id);

        //图标更新：
        GetControl<Image>("ItemIcon").sprite = ResourcesMgr.GetInstance().Load<Sprite>("Icon/" + itemData.icon);
        //名称字符更新：
        GetControl<Text>("ItemText").text = itemData.name;

    }

}
