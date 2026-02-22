using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : SingletonBase<PlayerInventory>
{
    private bool showInventoryProcessed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
        showInventoryProcessed = false;
    }

    private void ShowInventory()
    {
        if (Input.GetKey(InputHandler.instance.showInventory) && !showInventoryProcessed && LevelManager.instance.GetSceneName() != "Menu" && GameplayMenu.instance.IsGameplayMenuActive() == false)
        {
            if (EvidenceInventory.instance.GetActivated())
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(false);
                ProfileInventory.instance.SetActivatedInventoryMembers(false);
                ElectionBox.instance.SetButtonsActive(true);
                TextBox.instance.SetNextButtonActive(true);
                TextBox.instance.SetNextDebateButtonActive(true);
                TextBox.instance.SetPreviousDebateButtonActive(true);
            }
            else
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(true);
                ProfileInventory.instance.SetActivatedInventoryMembers(false);
                ElectionBox.instance.SetButtonsActive(false);
                TextBox.instance.SetNextButtonActive(false);
                TextBox.instance.SetNextDebateButtonActive(false);
                TextBox.instance.SetPreviousDebateButtonActive(false);
            }
            showInventoryProcessed = true;
        }
    }

    private void InventoryAllower()
    {
        if (LevelManager.instance.GetSceneName() != "Menu")
        {
            if (Input.GetKeyUp(InputHandler.instance.showInventory))
            {
                showInventoryProcessed = false;
            }
        }
    }

    protected override void BehaveSingleton()
    {
        if (InputHandler.instance.inputDetected())
        {
            ShowInventory();
        }
        InventoryAllower();
    }

    void Update()
    {
        BehaveSingleton();
    }
}
