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

    public void PressingBackToMenu()
    {
        InteractionsManager.instance.ClearInteractions(); // Pending to make a menu for this (Hollow)
        GameplayMenu.instance.DeactivateGameplayMenuOutside();
        LevelManager.instance.ChangeScene(menuScene);
    }
}
