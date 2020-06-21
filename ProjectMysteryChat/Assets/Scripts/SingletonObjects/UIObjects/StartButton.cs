using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : SingletonBase<StartButton>
{
    [SerializeField]
    string startScene;

    private void Awake()
    {
        SingletonAwake();
    }

    public void PressingStart() 
    {
        LevelManager.instance.ChangeScene(startScene);
    }
}
