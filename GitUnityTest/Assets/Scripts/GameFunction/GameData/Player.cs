using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


/// <summary>
/// 玩家数据模板类
/// </summary>
public class Player
{
    public string name;
    public int score;
    public float health;
    public List<ItemInfo> Slots;
    

    public Player()
    {
        name = "Race man";
        score = 0;
        Slots = new List<ItemInfo>() { };
    }

    //添加到玩家物品列中
    public void AddItem(ItemInfo info)
    {
        Item item = GameDataMgr.GetInstance().GetItemInfo(info.id);

        Slots.Add(info);
    }

    public void SetHealth(float modifer)
    {
        //判断钱够不够减 避免减成负数
        if (health < 0 && this.health < health)
            return;

        this.health += modifer;
    }
}