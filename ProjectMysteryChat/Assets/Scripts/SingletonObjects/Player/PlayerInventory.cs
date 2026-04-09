using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : SingletonBase<PlayerInventory>
{
    private bool showInventoryProcessed;
    private bool showProfilesProcessed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
        showInventoryProcessed = false;
        showProfilesProcessed = false;
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
                //TextBox.instance.SetNextButtonActive(true);
                //TextBox.instance.SetNextDebateButtonActive(true);
                //TextBox.instance.SetPreviousDebateButtonActive(true);
            }
            else if (ProfileInventory.instance.GetActivated()) 
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(true);
                ProfileInventory.instance.SetActivatedInventoryMembers(false);
                ElectionBox.instance.SetButtonsActive(false);
                //TextBox.instance.SetNextButtonActive(false);
                //TextBox.instance.SetNextDebateButtonActive(false);
                //TextBox.instance.SetPreviousDebateButtonActive(false);
            }
            else
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(true);
                ProfileInventory.instance.SetActivatedInventoryMembers(false);
                ElectionBox.instance.SetButtonsActive(false);
                //TextBox.instance.SetNextButtonActive(false);
                //TextBox.instance.SetNextDebateButtonActive(false);
                //TextBox.instance.SetPreviousDebateButtonActive(false);
            }
            showInventoryProcessed = true;
        }
    }

    private void ShowProfiles() 
    {
        if (Input.GetKey(InputHandler.instance.showProfiles) && !showProfilesProcessed && LevelManager.instance.GetSceneName() != "Menu" && GameplayMenu.instance.IsGameplayMenuActive() == false)
        {
            if (ProfileInventory.instance.GetActivated())
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(false);
                ProfileInventory.instance.SetActivatedInventoryMembers(false);
                ElectionBox.instance.SetButtonsActive(true);
                //TextBox.instance.SetNextButtonActive(true);
                //TextBox.instance.SetNextDebateButtonActive(true);
                //TextBox.instance.SetPreviousDebateButtonActive(true);
            }
            else if (EvidenceInventory.instance.GetActivated()) 
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(false);
                ProfileInventory.instance.SetActivatedInventoryMembers(true);
                ElectionBox.instance.SetButtonsActive(false);
                //TextBox.instance.SetNextButtonActive(false);
                //TextBox.instance.SetNextDebateButtonActive(false);
                //TextBox.instance.SetPreviousDebateButtonActive(false);
            }
            else
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(false);
                ProfileInventory.instance.SetActivatedInventoryMembers(true);
                ElectionBox.instance.SetButtonsActive(false);
                //TextBox.instance.SetNextButtonActive(false);
                //TextBox.instance.SetNextDebateButtonActive(false);
                //TextBox.instance.SetPreviousDebateButtonActive(false);
            }
            showProfilesProcessed = true;
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
            if (Input.GetKeyUp(InputHandler.instance.showProfiles)) 
            {
                showProfilesProcessed = false;
            }
        }
    }

    protected override void BehaveSingleton()
    {
        if (InputHandler.instance.inputDetected())
        {
            ShowInventory();
            ShowProfiles();
        }
        InventoryAllower();
    }

    void Update()
    {
        BehaveSingleton();
    }
}
