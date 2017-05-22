using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseView : MonoBehaviour {

    //进入
    public virtual void OnEnter(BaseContext context) {
        gameObject.SetActive(true);
    }
    //退出
    public virtual void OnExit(BaseContext context) {
        gameObject.SetActive(false);
    }
    //暂停
    public virtual void OnPause(BaseContext context) { 
    }
    //重置
    public virtual void OnResume(BaseContext context) {
    }

    public void DestorySelf() {
        Destroy(gameObject);
    }

}
