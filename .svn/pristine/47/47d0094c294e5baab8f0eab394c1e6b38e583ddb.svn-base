using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType  {

    public string Path { get; private set; }
    public string Name { get; private set; }

    public  UIType(string path) {
        Path = path;
        Name=path.Substring(path.LastIndexOf('/') + 1);
    }

   public  override string ToString() {
        return string.Format("path : {0} name : {1}", Path, Name);
    }


    public static readonly UIType LoginView = new UIType("Prefab/00_LoginScene/LoginView");
    public static readonly UIType CreateRoomView = new UIType("Prefab/01_CreateRoomScene/CreateRoomView");
    public static readonly UIType HallView = new UIType("Prefab/01_CreateRoomScene/ChessCardHallView");
    public static readonly UIType MahjongUIView = new UIType("Prefab/02_MainScene/MajiangGameUIView");


}
