﻿using UnityEngine;
using System.Collections;
using GameProtocol.Model;
using GameProtocol;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loninViewContext : BaseContext
{ 
    public loninViewContext() : base(UIType.LoginView)
    {
    }
}

public class LoginView : BaseView
{

    //public UIButton m_QQLoginBtn;

    //public UIButton m_WeChatLoginBtn;
    public GameObject obj_LoginMessage;

    public InputField input_Account;       //玩家账号输入框

    public InputField input_Password;
    public Button btnLogin;
    public Button btnRegin;

    public bool isOnline = false;       //表示玩家当前是否处于在线状态（临时）

    private void Start()
    {
        OnOnlineButtonClick();
        AudioManager.Instance.PlayBackgrounfAudio("playing");
    }
    /// <summary>
    /// 玩家登陆
    /// </summary>
    public void OnButtonLoginClick()
    {
        Debug.Log("登陆按钮被按下"); 
        AudioManager.Instance.PlayEffectAudio("ui_click");
        //(临时)
        if (isOnline)
        {
            if (input_Account.text.Length == 0 || input_Account.text.Length > 15)
            {
                Debug.Log("账号不合法");
                return;
            }
            if (input_Password.text.Length == 0 || input_Password.text.Length > 15)
            {
                Debug.Log("密码不合法");
                return;
            }           
            //验证通过则进行消息发送
            AccountModel model = new AccountModel();
            model.name = input_Account.text;
            model.password = input_Password.text;            
            NetManager.m_Instance.SendMessage(Protocol.TYPE_LOGIN, 0, LoginProtocol.LOGIN_CREQ, model);
        }
        else
        {
            //当前属于离线状态，直接登陆游戏
            Debug.Log("当前属于离线状态!");
            SceneManager.LoadScene("CreateRoomScene");
        }
        //btnLogin.GetComponent<Collider>().enabled = false;
    }

    /// <summary>
    /// 玩家注册
    /// </summary>
    public void OnButtonRegisterClick()
    {
        Debug.Log("注册按钮被按下");
        AudioManager.Instance.PlayEffectAudio("ui_click");
        if (input_Account.text.Length == 0 || input_Account.text.Length > 15)
        {
            Debug.Log("账号不合法");
            return;
        }
        if (input_Password.text.Length == 0 || input_Password.text.Length > 15)
        {
            Debug.Log("密码不合法");
            return;
        }
        //验证通过则进行消息发送
        AccountModel model = new AccountModel();
        model.name = input_Account.text;
        model.password = input_Password.text;
        NetManager.m_Instance.SendMessage(Protocol.TYPE_LOGIN, 0, LoginProtocol.REG_CREQ, model);
        //btnRegin.GetComponent<Collider>().enabled = false;
    }

    /// <summary>
    /// QQ登陆
    /// </summary>
    public void OnQQButtonClick()
    {
        Debug.Log("QQ登陆按钮按下");
        string message = "QQ";
        GameEngine.m_Instance.m_NetMgr.SendMessage(message);
    }

    /// <summary>
    /// 微信登陆
    /// </summary>
    public void OnWeChatButtonClick()
    {
        Debug.Log("微信登陆按钮按下");
        string message = "WeChat";
        GameEngine.m_Instance.m_NetMgr.SendMessage(message);
    }


    //临时按钮，点击在线按钮连接服务器
    public void OnOnlineButtonClick()
    {
        StartCoroutine(ChagedIP());
    }
    IEnumerator ChagedIP() {
        //读取本地IP　文件
#if UNITY_EDITOR
        string path = "file:///" + Application.streamingAssetsPath + "/IPConfig.txt";
#elif UNITY_ANDROID
        string path = Application.streamingAssetsPath + "/IPConfig.txt";
#endif
        WWW www = new WWW(path);
        yield return www;
        if (www.isDone && www.error == null)
        {
            string ip = www.text;
            ConnectServer.ip = ip.Split(':')[0];
            ConnectServer.port = int.Parse(ip.Split(':')[1]);
            Debug.Log("IP 已修改为：" + ip);

            Debug.Log("在线按钮按下");
            isOnline = true;
            GameEngine.m_Instance.ConnectTo();
        }
    }
    //临时按钮，点击离线按钮连接服务器
    public void OnOfflineButtonClick()
    {        
        Debug.Log("离线按钮按下");
        isOnline = false;
        GameEngine.m_Instance.CloseSocket();
    }
    

#region Override Base Method

    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);
    }
    public override void OnPause(BaseContext context)
    {
        base.OnPause(context);
        this.gameObject.SetActive(false);
    }
    public override void OnResume(BaseContext context)
    {
        base.OnResume(context);
        this.gameObject.SetActive(true);
    }
    public override void OnExit(BaseContext context)
    {
        base.OnExit(context);
    }
#endregion

}
