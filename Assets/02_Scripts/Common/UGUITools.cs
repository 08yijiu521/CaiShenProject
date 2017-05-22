using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 static public class UGUITools  {



    static public void SetChild(this GameObject parent, GameObject prefab) {
        prefab.transform.SetSiblingIndex(10);//同级顺序

    }
    static public GameObject AddChild(this GameObject parent, GameObject prefab) { return parent.AddChild(prefab, -1); }
    static public GameObject AddChild(this GameObject parent, GameObject prefab, int layer)
    {
        GameObject go = GameObject.Instantiate(prefab) as GameObject;
#if UNITY_EDITOR
        if (!Application.isPlaying)
            UnityEditor.Undo.RegisterCreatedObjectUndo(go, "Create Object");
#endif
        if (go != null && parent != null)
        {
            Transform t = go.transform;
            t.parent = parent.transform;
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            if (layer == -1) go.layer = parent.layer;
            else if (layer > -1 && layer < 32) go.layer = layer;
        }
        return go;
    }

}
