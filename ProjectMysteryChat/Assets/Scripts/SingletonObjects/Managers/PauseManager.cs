using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : SingletonBase<PauseManager>
{
    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public bool Paused()
    {
        return !(TextBox.instance.GetActivated() == false &&
                EvidenceInventory.instance.GetActivated() == false &&
                ElectionBox.instance.GetActivated() == false &&
                CutsceneManager.instance.GetActivated() == false); // Add gameplay menu activated (Hollow)
    }
}
