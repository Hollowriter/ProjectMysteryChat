using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : SingletonBase<QuitButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void PressingQuit()
    {
        Application.Quit();
    }
}
