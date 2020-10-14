using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAlgorithm : SceneAlgorithm // NOTA: PENDIENTE DE TERMINAR
{
    public string dialogForTheScene;
    bool dialogIsSet;

    void Begin() 
    {
        dialogFile = dialogForTheScene;
        dialogIsSet = false;
    }

    private void Awake()
    {
        Begin();
    }

    void InsertDialog() 
    {
        if (!dialogIsSet) 
        {
            DocumentManager.instance.SetDocument(dialogFile);
            TextBox.instance.SetActivated(true);
            dialogIsSet = true;
        }
    }

    void CheckEndAlgorithm() 
    {
        if (!TextBox.instance.GetActivated()) 
        {
            if (!ElectionBox.instance.GetActivated()) 
            {
                if (dialogIsSet)
                {
                    SetAlgorithmEnd(true);
                }
            }
        }
    }

    public override void ActScript()
    {
        InsertDialog();
        CheckEndAlgorithm();
    }
}
