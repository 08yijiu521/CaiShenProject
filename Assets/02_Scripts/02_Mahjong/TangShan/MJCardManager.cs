using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MJCardManager : MonoBehaviour
{
    public static Sprite[] cardSprites;
    public Texture text;
    public void FaPai()
    {

    }

    /// <summary>
    /// 根据ID获取指定的牌
    /// 1-9 ：  万
    /// 11-19： 条
    /// 21-29： 筒
    /// </summary>
    public static Sprite getCardSprite(int id)
    { 
        string SPName = id.ToString(); 

        foreach (var sp in cardSprites)
        {
            if (sp.name == SPName)
            {
                return sp;
            }
        }
        return null;
    }
}
