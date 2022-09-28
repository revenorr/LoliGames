using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static Action OnLvlUP;

    public static void LvlUpAction()
    {
        if (OnLvlUP != null) OnLvlUP.Invoke();

    }
        
    
}
