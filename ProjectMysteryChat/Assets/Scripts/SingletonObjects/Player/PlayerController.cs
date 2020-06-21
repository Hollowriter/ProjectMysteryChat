using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
    [SerializeField]
    int playerSpeed;
    bool showInventoryProcessed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
        showInventoryProcessed = false;
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
        if (Input.GetKey(InputHandler.instance.walkUp))
        {
            transform.position += (Vector3.forward) * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(InputHandler.instance.walkDown))
        {
            transform.position -= (Vector3.forward) * playerSpeed * Time.deltaTime;
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

    public void InteractObject()
    {
        if (PlayerCollisionManager.instance.GetInteractObject() != null)
        {
            if (Input.GetKey(InputHandler.instance.interact))
            {
                PlayerCollisionManager.instance.GetInteractObject().BehaveInteraction();
            }
        }
    }

    public void ShowInventory()
    {
        if (Input.GetKey(InputHandler.instance.showInventory) && !showInventoryProcessed)
        {
            if (EvidenceInventory.instance.GetActivated())
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(false);
            }
            else
            {
                EvidenceInventory.instance.SetActivatedInventoryMembers(true);
            }
            showInventoryProcessed = true;
        }
    }

    public void ProcessAllower()
    {
        if (Input.GetKeyUp(InputHandler.instance.showInventory))
            showInventoryProcessed = false;
    }

    bool AllGUIDeactivated()
    {
        return TextBox.instance.GetActivated() == false &&
                EvidenceInventory.instance.GetActivated() == false &&
                ElectionBox.instance.GetActivated() == false;
    }

    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            if (AllGUIDeactivated())
            {
                MovementKeys();
                InteractObject();
            }
            ShowInventory();
        }
        ProcessAllower();
    }

    void Update()
    {
        BehaveSingleton();
    }
}
