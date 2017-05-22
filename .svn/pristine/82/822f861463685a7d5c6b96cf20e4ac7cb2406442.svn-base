
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameProtocol;
using DG.Tweening;
using DG;
public class CreateRoomViewContext : BaseContext
{
    public CreateRoomViewContext() : base(UIType.CreateRoomView)
    {
    }
}

public class CreateRoomViewMgr : BaseView
{   
    public Button Btn_CloseRoomNumPanel;          //关闭加入房间窗口按钮
    public Button Btn_CreateRoom;                 //创建房间按钮
    public Button Btn_JoinRoom;                   //加入房间按钮        
    public Text Label_UserName;                  //玩家用户名
    public Text  Label_Diamond;                   //玩家钻石数显示
    public Image Img_UserIcon;                     //玩家头像

    public GameObject joinRoomWindow;

    public bool isClick = false;
    public static CreateRoomViewMgr m_Instance = null;

    private void Awake()
    {
        m_Instance = this;
    }

    void Start () {

        #region 创建房间场景按键相应事件 

        Btn_CreateRoom.onClick.AddListener(OnCreateRoomBtnClick);
        Btn_JoinRoom.onClick.AddListener(OnJoinRoomBtnClick);
        Btn_CloseRoomNumPanel.onClick.AddListener(OnCloseRoomNumPanelClick);
        #endregion
    }


    /// <summary>
    /// 创建房间场景UI初始化
    /// </summary>
    public void _Init()
    {
        Debug.Log("_Init");
        Label_UserName.text = PlayerMgr.m_Instance.PlayerName.ToString();
        Label_Diamond.text = PlayerMgr.m_Instance.PlayerDiamond.ToString();
        Img_UserIcon.sprite.name = InitPlayerIcon(PlayerMgr.m_Instance.IconNum);
    }

    /// <summary>
    /// 初始化玩家头像
    /// </summary>
    /// <param name="IconNum"></param>
    /// <returns></returns>
    public string InitPlayerIcon(int IconNum)
    {
        switch (IconNum)
        {
            case 1:
                return "Img_tx01";
            case 2:
                return "Img_tx02";
            case 3:
                return "Img_tx03";
            case 4:
                return "Img_tx04";
            default:
                Debug.Log("错误玩家头像ID！");
                return null;
        }
    }

    //创建房间按钮点击事件
    public void OnCreateRoomBtnClick()
    {
        Debug.Log("创建房间按钮被按下");
        AudioManager.Instance.PlayEffectAudio("ui_click");
        //向服务器发送创建房间请求
        NetManager.m_Instance.SendMessage(Protocol.TYPE_ROOM, 0, RoomProtocol.CREATE_CREQ, null); 
    }

    //加入房间按钮点击事件
    public void OnJoinRoomBtnClick()
    {
        AudioManager.Instance.PlayEffectAudio("ui_click");
        //显示输入房间面板 
        joinRoomWindow.gameObject.SetActive(true);
        joinRoomWindow.transform.DOScale(1.0f, 0.2f); 
        //将创建房间，加入房间按钮禁用掉
    }

    //关闭输入房间号码面板按钮点击事件
    public void OnCloseRoomNumPanelClick()
    {
        AudioManager.Instance.PlayEffectAudio("ui_click");
        joinRoomWindow.transform.DOScale(1.0f, 0.2f);
        //joinRoomWindow.GetComponent<TweenScale>().PlayReverse();
        CheckRoomNum.instance.ResetRoomNum();
        joinRoomWindow.gameObject.SetActive(false); 
    }
    public void Return() {
        Singleton<ContextManager>.Instance.Pop(); 
    }

    #region Override Base Method

    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);
        NetManager.m_Instance.SendMessage(Protocol.TYPE_USER, 0, UserProtocol.INFO_CREQ, null); 
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
        this.gameObject.SetActive(false);
    }
    #endregion

}
