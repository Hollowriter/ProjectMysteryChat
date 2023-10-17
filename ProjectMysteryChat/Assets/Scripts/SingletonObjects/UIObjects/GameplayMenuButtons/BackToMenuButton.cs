using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuButton : SingletonBase<BackToMenuButton>
{
    [SerializeField]
    string menuScene;

    private void Awake()
    {
        SingletonAwake();
    }

    public void PressingStart()
    {
        InteractionsManager.instance.ClearInteractions(); // Pending to make a menu for this (Hollow)
        LevelManager.instance.ChangeScene(menuScene);
    }
}
