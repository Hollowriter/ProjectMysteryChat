using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
    [SerializeField]
    int playerSpeed;
    bool showInventoryProcessed;
    bool interactionPressed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
        showInventoryProcessed = false;
        interactionPressed = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    protected override bool ConditionsToBeActive()
    {
        if (InputHandler.instance != null)
        {
            if (InputHandler.instance.inputDetected())
            {
                SetActivated(true);
                return GetActivated();
            }
        }
        SetActivated(false);
        return GetActivated();
    }

    public void MovementKeys()
    {
        if (!PauseManager.instance.Paused())
        {
            if (Input.GetKey(InputHandler.instance.walkUp))
            {
                transform.position += (Vector3.up) * playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(InputHandler.instance.walkDown))
            {
                transform.position += (Vector3.down) * playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(InputHandler.instance.walkLeft))
            {
                transform.position += (Vector3.left) * playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(InputHandler.instance.walkRight))
            {
                transform.position += (Vector3.right) * playerSpeed * Time.deltaTime;
            }
        }
    }

    public void InteractObject()
    {
        if (PlayerCollisionManager.instance.GetInteractObject() != null && !PauseManager.instance.Paused())
        {
            if (Input.GetKey(InputHandler.instance.interact) && !interactionPressed)
            {
                interactionPressed = true;
                PlayerCollisionManager.instance.GetInteractObject().BehaveInteraction();
            }
        }
        if (Input.GetKeyUp(InputHandler.instance.interact))
        {
            interactionPressed = false;
        }
    }

    public void ShowInventory()
    {
        if (Input.GetKey(InputHandler.instance.showInventory) && !showInventoryProcessed)
        {
            if (EvidenceInventory.instance.GetActivated())
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(false);
                ElectionBox.instance.SetButtonsActive(true);
                TextBox.instance.SetNextButtonActive(true);
            }
            else
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(true);
                ElectionBox.instance.SetButtonsActive(false);
                TextBox.instance.SetNextButtonActive(false);
            }
            showInventoryProcessed = true;
        }
    }

    public void ProcessAllower()
    {
        if (LevelManager.instance.GetSceneName() != "Menu")
        {
            if (Input.GetKeyUp(InputHandler.instance.showInventory))
            {
                showInventoryProcessed = false;
            }
        }
    }

    public void InteractionProcessAllower()
    {
        interactionPressed = false;
    }

    public void ChangePlayerPosition(float newPlayerPositionX, float newPlayerPositionY)
    {
        this.gameObject.transform.position = new Vector3(newPlayerPositionX, newPlayerPositionY, PlayerController.instance.gameObject.transform.position.z);
    }

    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            MovementKeys();
            InteractObject();
            ShowInventory();
            return;
        }
        ProcessAllower();
        InteractionProcessAllower();
    }

    void Update()
    {
        BehaveSingleton();
    }
}
