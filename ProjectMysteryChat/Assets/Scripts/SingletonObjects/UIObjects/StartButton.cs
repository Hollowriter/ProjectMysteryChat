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
        InteractionsManager.instance.ClearInteractions(); // Pending to make a menu for this (Hollow)
        LevelManager.instance.ChangeScene(startScene);
    }
}
