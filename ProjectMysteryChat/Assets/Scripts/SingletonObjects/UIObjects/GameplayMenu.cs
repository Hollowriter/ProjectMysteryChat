using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMenu : SingletonBase<GameplayMenu>
{
    private bool gameplayMenuActivated;
    private bool showGameplayMenuProcessed;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject loadButton;
    [SerializeField] private GameObject backToMenuButton;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        gameplayMenuActivated = false;
        showGameplayMenuProcessed = false;
        resumeButton.SetActive(false);
        loadButton.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void ShowGameplayMenu()
    {
        if (Input.GetKey(InputHandler.instance.showGameplayMenu) && !showGameplayMenuProcessed && LevelManager.instance.GetSceneName() != "Menu" && EvidenceInventory.instance.GetActivated() == false)
        {
            if (!gameplayMenuActivated)
            {
                gameplayMenuActivated = true;
                resumeButton.SetActive(true);
                loadButton.SetActive(true);
                loadButton.GetComponent<LoadButton>().ActivateLoadButton();
                backToMenuButton.SetActive(true);
                ElectionBox.instance.SetButtonsActive(false);
                TextBox.instance.SetNextButtonActive(false);
                TextBox.instance.SetNextDebateButtonActive(false);
                TextBox.instance.SetPreviousDebateButtonActive(false);
            }
            else
            {
                gameplayMenuActivated = false;
                resumeButton.SetActive(false);
                loadButton.SetActive(false);
                backToMenuButton.SetActive(false);
                ElectionBox.instance.SetButtonsActive(true);
                TextBox.instance.SetNextButtonActive(true);
                TextBox.instance.SetNextDebateButtonActive(true);
                TextBox.instance.SetPreviousDebateButtonActive(true);
            }
            showGameplayMenuProcessed = true;
        }
    }

    private void GameplayMenuAllower()
    {
        if (LevelManager.instance.GetSceneName() != "Menu")
        {
            if (Input.GetKeyUp(InputHandler.instance.showGameplayMenu))
            {
                showGameplayMenuProcessed = false;
            }
        }
    }

    public void DeactivateGameplayMenuOutside() 
    {
        if (gameplayMenuActivated)
        {
            gameplayMenuActivated = false;
            resumeButton.SetActive(false);
            loadButton.SetActive(false);
            backToMenuButton.SetActive(false);
            ElectionBox.instance.SetButtonsActive(true);
            TextBox.instance.SetNextButtonActive(true);
            TextBox.instance.SetNextDebateButtonActive(true);
            TextBox.instance.SetPreviousDebateButtonActive(true);
        }
    }

    public bool IsGameplayMenuActive() 
    {
        return gameplayMenuActivated;
    }

    protected override void BehaveSingleton()
    {
        if (InputHandler.instance.inputDetected())
        {
            ShowGameplayMenu();
        }
        GameplayMenuAllower();
    }

    void Update()
    {
        BehaveSingleton();
    }
}
