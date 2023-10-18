using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public void PressingLoad() 
    {
        GameplayMenu.instance.DeactivateGameplayMenuOutside();
        SaveDataDocument.instance.Load();
    }
}
