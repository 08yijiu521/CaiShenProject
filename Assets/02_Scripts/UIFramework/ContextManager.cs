using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 
 * 上下文 管理器
 * 
 */
public class ContextManager
{

    private Stack<BaseContext> _contextStack = new Stack<BaseContext>();

    private ContextManager()
    {
        Push(new loninViewContext());
    }
    // 跳转页面
    public void Push(BaseContext nextContext)
    {

        if (_contextStack.Count != 0)
        {
            BaseContext curContext = _contextStack.Peek();
            BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(curContext.viewType).GetComponent<BaseView>();
            curView.OnPause(curContext);
        }
        _contextStack.Push(nextContext);
        BaseView nextView = Singleton<UIManager>.Instance.GetSingleUI(nextContext.viewType).GetComponent<BaseView>();
        nextView.OnEnter(nextContext);

    }
    //推出页面
    public void Pop()
    {
        if (_contextStack.Count != 0)
        {
            BaseContext curContext = _contextStack.Peek();
            _contextStack.Pop();

            BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(curContext.viewType).GetComponent<BaseView>();
            curView.OnExit(curContext);
        }


        if (_contextStack.Count != 0)
        {
            BaseContext lastContext = _contextStack.Peek();
            BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(lastContext.viewType).GetComponent<BaseView>();
            curView.OnResume(lastContext);
        }

    }


    public BaseContext PeekOrNull()
    { 
        if (_contextStack.Count != 0)
        {
            return _contextStack.Peek();
        }
        return null;
    }


}
