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
        InteractionsManager.instance.ClearInteractions();
        EvidenceInventory.instance.ClearInventory();
        GameplayMenu.instance.DeactivateGameplayMenuOutside();
        SpaceInstruction.instance.deactivateElements?.Invoke();
        LevelManager.instance.ChangeScene(menuScene);
    }
}
