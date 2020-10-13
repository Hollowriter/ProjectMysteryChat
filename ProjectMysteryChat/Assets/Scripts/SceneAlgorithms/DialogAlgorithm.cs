using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAlgorithm : SceneAlgorithm // NOTA: PENDIENTE DE TERMINAR
{
    public string[] dialogsForTheScene;
    int dialogsFinished;

    void Begin() 
    {
        dialogFiles = dialogsForTheScene;
        dialogsFinished = 0;
    }

    private void Awake()
    {
        Begin();
    }

    public int GetDialogsFinished() 
    {
        return dialogsFinished;
    }

    public override void ActScript()
    {
        throw new System.NotImplementedException();
    }
}
