using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 
 * UI界面管理器，View 的创建和删除 
 */
public class UIManager
{
    public Dictionary<UIType, GameObject> _UIDic = new Dictionary<UIType, GameObject>();
    Transform _canvas;

    public UIManager()
    {
        _canvas = GameObject.Find("Canvas_UI/Main_UI").transform;

        foreach (Transform item in _canvas)
        {
            GameObject.Destroy(item.gameObject);
        }
    }

    public GameObject GetSingleUI(UIType uiType)
    {
        if (_UIDic.ContainsKey(uiType) == false|| _UIDic[uiType] == null)
        {
            GameObject go =GameObject.Instantiate( Resources.Load<GameObject>(uiType.Path));
            go.transform.SetParent(_canvas);
            RectTransform rectTransform = (RectTransform)(go.transform as RectTransform);
            rectTransform.localPosition = Vector3.zero;
            rectTransform.sizeDelta = Vector2.zero;
            go.name = uiType.Name;
            _UIDic.Add(uiType, go);
            return go;
        }
        return _UIDic[uiType];
    }

    public void DestorySingUI(UIType uiType)
    {
        if (!_UIDic.ContainsKey(uiType))
        {
            return;
        }
        if (_UIDic[uiType] == null)
        {
            _UIDic.Remove(uiType);
            return;
        }

        GameObject.Destroy(_UIDic[uiType]);
        _UIDic.Remove(uiType);

    }

}
