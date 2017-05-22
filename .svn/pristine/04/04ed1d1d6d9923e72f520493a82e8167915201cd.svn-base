using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MahjongGameUIViewContext : BaseContext
{
    public MahjongGameUIViewContext() : base(UIType.MahjongUIView)
    {
    }
}

public class MahjongGameUIView : BaseView {
    public GameObject GameRoot;
    private void Awake()
    {
        GameRoot = GameObject.Find("Canvas_UI/GameRoot");
    }

    #region Override Base Method

    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);
        GameObject mahjongObj = Instantiate(Resources.Load<GameObject>("Prefab/02_MainScene/Mahjong_GameRoot"));
        mahjongObj.SetActive(true);
        mahjongObj.transform.SetParent(GameRoot.transform);
        mahjongObj.transform.localPosition = Vector3.zero;
    }
    public override void OnPause(BaseContext context)
    {
        base.OnPause(context);
        this.gameObject.SetActive(false);
    }
    public override void OnResume(BaseContext context)
    {
        base.OnResume(context);
    }
    public override void OnExit(BaseContext context)
    {
        base.OnExit(context);
    }
    #endregion
    

}
