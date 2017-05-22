using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {
    // 单利创建
    public void Start()
    {
        Singleton<UIManager>.Create();
        Singleton<ContextManager>.Create(); 
    }
}
