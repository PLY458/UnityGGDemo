using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameDataMgr : BaseManeger<GameDataMgr>
{

    private Dictionary<int, Item> itemInfos = new Dictionary<int, Item>();



    private static string SavePath_Url = Application.persistentDataPath + "/SaveInfo.txt";

    public void Init()
    {
        //ResourcesMgr同步读取json信息
        string info = ResourcesMgr.GetInstance().Load<TextAsset>("Json/ItemInfo").text;
        //使用JsonUtility解释json物品列信息
        Itemlist items = JsonUtility.FromJson<Itemlist>(info);
        for (int i = 0; i < items.info.Count; ++i)
        {
            itemInfos.Add(items.info[i].id, items.info[i]);
        }
    }


    /// <summary>
    /// JSON文件流存档
    /// </summary>
    public void Save()
    {
        //示例
        string json = JsonUtility.ToJson(new Item());
        //文件写入
        File.WriteAllBytes(SavePath_Url, Encoding.UTF8.GetBytes(json));

    }

    /// <summary>
    /// JSON文件流读档
    /// </summary>
    public void load()
    {
        //检测存档路径是否存在
        if (File.Exists(SavePath_Url))
        {
            //读取得到字节数组
            byte[] bytes = File.ReadAllBytes(SavePath_Url);
            //
            string json = Encoding.UTF8.GetString(bytes);
        }
        else {
            //创建新的数据档案
        }
    }


    /// <summary>
    /// 检索并得到物品
    /// </summary>
    /// <param name="id">物品唯一认证码</param>
    /// <returns></returns>
    public Item GetItemInfo(int id)
    {
        if (itemInfos.ContainsKey(id))
            return itemInfos[id];
        return null;
    }
}



public class Itemlist
{
    //固定命名
    public List<Item> info;
}

/// <summary>
/// 物品属性模板类
/// </summary>
[System.Serializable]
public class Item
{
    public int id; // 2
    public string name; // 板甲
    public string icon; // 2
    public bool isShow; // False
    public int type; // 2
    public int equipSlot; // 1
    public float armorModifier; // 5
    public float damageModifier; // 0
}
