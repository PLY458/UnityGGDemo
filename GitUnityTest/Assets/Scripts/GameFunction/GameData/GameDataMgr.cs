using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

/// <summary>
/// 游戏数据管理器(未完成)
/// </summary>
public class GameDataMgr : BaseManeger<GameDataMgr>
{
    //数字作为索引检索背包系统
    private Dictionary<int, Item> p_itemInfos = new Dictionary<int, Item>();

    private static string SavePath_Url = Application.persistentDataPath + "/SaveInfo.txt";

    /// <summary>
    /// 初始化初始信息
    /// </summary>
    public void Init()
    {
        //ResourcesMgr同步读取json信息
        string info = ResourcesMgr.GetInstance().Load<TextAsset>("Json/ItemInfo").text;
        Debug.Log("GameDataMgr读取内容:"+ info);
        //使用JsonUtility解释json物品列信息
        Itemlist items = JsonUtility.FromJson<Itemlist>(info);
        Debug.Log(items.info.Count);
        for (int i = 0; i < items.info.Count; ++i)
        {
            p_itemInfos.Add(items.info[i].id, items.info[i]);
        }
        //下面可用save和load初始化角色数据
    }

    /// <summary>
    /// JSON文件流存档
    /// </summary>
    public void Save<T>( T saveTemplate)
    {
        //示例
        string json = JsonUtility.ToJson(saveTemplate);
        //文件写入
        File.WriteAllBytes(SavePath_Url, Encoding.UTF8.GetBytes(json));

    }

    /// <summary>
    /// JSON文件流读档
    /// 注意：loadTemplate必须已经得到实例化
    /// </summary>
    public void load<T>(T loadTemplate)
    {
        //检测存档路径是否存在
        if (File.Exists(SavePath_Url))
        {
            //读取得到字节数组
            byte[] bytes = File.ReadAllBytes(SavePath_Url);
            //把字节数值转成字符串
            string json = Encoding.UTF8.GetString(bytes);
            //在吧字符串转成需要的数据结构
            //用例：
            loadTemplate = JsonUtility.FromJson<T>(json);
        }
        else {
            //创建新的数据档案
            Save<T>(loadTemplate);
        }
    }


    /// <summary>
    /// 检索并得到物品
    /// </summary>
    /// <param name="id">物品唯一认证码</param>
    /// <returns></returns>
    public Item GetItemInfo(int id)
    {
        if (p_itemInfos.ContainsKey(id))
            return p_itemInfos[id];
        return null;
    }

}

/// <summary>
/// 格子显示的基础信息
/// </summary>
[System.Serializable]
public class ItemInfo
{
    public int id;
    public int num;
}


/// <summary>
/// 临时链表表示道具表
/// </summary>
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
