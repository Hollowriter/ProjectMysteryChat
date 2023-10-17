using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : SingletonBase<LoadButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void PressingLoad() 
    {
        SaveDataDocument.instance.Load();
    }
}
