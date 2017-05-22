using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealController : MonoBehaviour {
    static DealController _instance;
    public static DealController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance) {
            DestroyImmediate(this);
        }
        _instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
    /// <summary>
    /// 发牌
    /// </summary>
    public void Deal()
    {
        
    }


    void initDeal() {

    }
}
