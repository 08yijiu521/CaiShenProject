using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseContext  {

   public  UIType viewType { get; private set; }

    public BaseContext(UIType _viewType) {
        viewType = _viewType;
    }

}
