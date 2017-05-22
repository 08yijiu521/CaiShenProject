﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HallViewContext : BaseContext
{
    public HallViewContext( ) : base(UIType.HallView)
    {
    }
}
/// <summary>
/// 棋牌大厅 
/// </summary>
public class HallView : BaseView {

    public Button maJiang, niuNiu, douDiZhu, Option; 
    //进入麻将
    public void MajiangOnClick() { 
        Singleton<ContextManager>.Instance.Push(new CreateRoomViewContext());
    }
    //进入牛牛
    public void NiuNiuOnClick() {
        Debug.Log("进入牛牛房间");
    }
    //进入斗地主
    public void DouDiZhuOnClick() {
        Debug.Log("进入斗地主房间");
    }
    //敬请期待
    public void OptionOnClick() {
        Debug.Log("敬请期待");
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
        this.gameObject.SetActive(false);
    }
    #endregion

}
