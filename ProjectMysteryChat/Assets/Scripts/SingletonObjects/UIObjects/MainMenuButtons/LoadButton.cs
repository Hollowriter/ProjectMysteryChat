﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{

    public void ActivateLoadButton() 
    {
        if (!SaveDataDocument.instance.IsSomethingSaved())
            this.gameObject.SetActive(false);
    }

    private void Start() 
    {
        ActivateLoadButton();
    }

    public void PressingLoad() 
    {
        GameplayMenu.instance.DeactivateGameplayMenuOutside();
        SaveDataDocument.instance.Load();
    }
}
