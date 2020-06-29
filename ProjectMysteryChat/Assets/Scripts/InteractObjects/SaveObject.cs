using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : InteractObject
{
    void SaveData() 
    {
        SaveDataDocument.instance.Save();
    }

    public override void BehaveInteraction()
    {
        SaveData();
    }
}
