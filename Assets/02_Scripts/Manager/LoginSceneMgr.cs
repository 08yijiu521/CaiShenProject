﻿/************************************************************************
*	@brief		：Login场景管理类.
*		
*	@author		：李经纬
*	@copyright	：时光科技   2017
*	
*	@date		：2017年2月22日15:54:57
************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GameProtocol;

public class LoginSceneMgr : MonoBehaviour {
    public static LoginSceneMgr m_Instance = null;

    public GameObject obj_LoginMessage; 

    private void Awake()
    {
        m_Instance = this;
    }

    // Use this for initialization
    void Start () {
        AudioManager.Instance.PlayBackgrounfAudio("playing");
	}
	
	
    /// <summary>
    /// 登陆返回处理
    /// </summary>
    public void login(int value)
    {
        switch (value)
        {
            case 0:
                Debug.Log("登陆成功");                 
                Singleton<ContextManager>.Instance.Push(new HallViewContext());
                break;
            case -1:
                obj_LoginMessage.GetComponent<LoginMessageInit>().InitBox("帐号不存在");
                UGUITools.AddChild(this.transform.parent.gameObject, obj_LoginMessage,10);

                Debug.Log("帐号不存在");
                break;
            case -2:
                Debug.Log("帐号在线");
                obj_LoginMessage.GetComponent<LoginMessageInit>().InitBox("帐号在线");
                UGUITools.AddChild(this.transform.parent.gameObject, obj_LoginMessage);

                break;
            case -3:
                Debug.Log("密码错误");
                obj_LoginMessage.GetComponent<LoginMessageInit>().InitBox("密码错误");
                UGUITools.AddChild(this.transform.parent.gameObject, obj_LoginMessage);

                break;
            case -4:
                Debug.Log("输入不合法");
                obj_LoginMessage.GetComponent<LoginMessageInit>().InitBox("输入不合法");
                UGUITools.AddChild(this.transform.parent.gameObject, obj_LoginMessage);

                break;
        }
    }
    /// <summary>
    /// 注册返回处理
    /// </summary>
    public void reg(int value)
    {
        switch (value)
        {
            case 0:
                Debug.Log("注册成功");
                obj_LoginMessage.GetComponent<LoginMessageInit>().InitBox("注册成功");
                UGUITools.AddChild(this.transform.parent.gameObject, obj_LoginMessage,10);

                //加载游戏主场景
                break;
            case 1:
                Debug.Log("注册失败，帐号重复");
                obj_LoginMessage.GetComponent<LoginMessageInit>().InitBox("注册失败，帐号重复");
                UGUITools.AddChild(this.transform.parent.gameObject, obj_LoginMessage);

                break;

        }
    }
}