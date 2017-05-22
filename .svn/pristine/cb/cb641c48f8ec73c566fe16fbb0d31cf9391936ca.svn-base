using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreCtr : MonoBehaviour {
    public Image m_PlayerIcon;
    public Text m_PlayerName;
    public Image m_Operator;
    public Image m_Number1;
    public Image m_Number2;
    public Image m_Number3;
   public void SetPlayerScore(string name,string icon,int score)
    {
        Debug.Log("初始化分数界面："+name);
        m_PlayerName.text = name;
        m_PlayerIcon.sprite.name = icon;
        InitScoreSpriteName(score);
        Debug.Log("初始化分数界面完成：" + name);
    }

    public void InitScoreSpriteName(int score)
    {
        string spriteName = "Img";
        if (score < 0)
        {
            spriteName = spriteName + "_";
            m_Operator.sprite.name = spriteName + "-";
        }
        else
        {
            m_Operator.sprite.name = spriteName + "+";
        }
        if (score < 10)
        {
            spriteName = spriteName + score;
            m_Number2.gameObject.SetActive(false);
            m_Number3.gameObject.SetActive(false);
        }
        else if(score < 100 && score >=10)
        {
            int num1 = score / 10;
            int num2 = score % 10;
            m_Number1.sprite.name = spriteName + num1;
            m_Number2.sprite.name = spriteName + num2;
            m_Number3.gameObject.SetActive(false);
        }
        else if(score >=100 && score < 1000)
        {
            int num1 = score / 100;
            int num3 = score % 100;
            int num2 = num3 / 10;
            num3 = num3 % 10;
            m_Number1.sprite.name = spriteName + num1;
            m_Number2.sprite.name = spriteName + num2;
            m_Number3.sprite.name = spriteName+num3;
        }
    }
}
