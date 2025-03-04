using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAlgorithm : SceneAlgorithm
{
    private void SaveAction() 
    {
        SaveDataDocument.instance.Save();
        SetAlgorithmEnd(true);
    }

    public override void ActScript()
    {
        SaveAction();
    }
}
