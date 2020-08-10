using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI页签状态枚举
/// </summary>
public enum E_Bag_Type
{
        Item,
        Equip,
        Gem,
}


/// <summary>
/// 背包逻辑页面
/// </summary>
public class BagPanel : UIBasePanel
{
    //挂载的父物体的位置
    public Transform listContent;
    //装载格子的缓冲链表
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    /// <summary>
    /// 初始化背包的各个组件监听事件
    /// </summary>
    private void InitBag()
    {
        //设置关闭按钮
        GetControl<Button>("btnClose").onClick.AddListener(HideMe);
        //设置页签按钮

    }


    private void Start()
    {
        
    }

    /// <summary>
    /// 回应页签转换的外观方法
    /// </summary>
    private void ToggeleValueChange() 
    {
        //检测菜单上的状态按钮是否被选中


    }

    /// <summary>
    /// 页签切换时的真事件逻辑函数
    /// </summary>
    /// <param name=""></param>
    private void ChangType(E_Bag_Type type)
    {
        //按照标记获取相应数据(switch)

        //更新面板的内容
        //先删除
        //循坏销毁每个预制体，然后清空链表

        //在更新
        //动态创建InventorySlot预制体，存到list中

            //实例化预设体并取得脚本

            //设置它的父对象

            //初始化数据

            //把他存进list
        

    }


    public override void HideMe()
    {
        base.HideMe();
        this.gameObject.SetActive(false);
    }



    public override void ShowMe()
    {
        base.ShowMe();
        this.gameObject.SetActive(true);
        //注意设置默认开启的页签
        //演示：
        ChangType(E_Bag_Type.Item);
    }
}
