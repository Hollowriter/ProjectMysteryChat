using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int playerSpeed;
    bool showInventoryProcessed;
    public static PlayerController mainPlayer = null; // Singleton class (Anotacion)

    private void Awake()
    {
        showInventoryProcessed = false;
        if (mainPlayer == null)
        {
            DontDestroyOnLoad(gameObject);
            mainPlayer = this;
        }
        else if (mainPlayer != this)
        {
            Destroy(gameObject);
        } // Singleton class (Anotacion)
    }

    public void MovementKeys()
    {
        if (Input.GetKey(InputHandler.input.walkUp))
        {
            transform.position += (Vector3.forward) * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(InputHandler.input.walkDown))
        {
            transform.position -= (Vector3.forward) * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(InputHandler.input.walkLeft))
        {
            transform.position += (Vector3.left) * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(InputHandler.input.walkRight))
        {
            transform.position += (Vector3.right) * playerSpeed * Time.deltaTime;
        }
    }

    public void InteractObject()
    {
        if (PlayerCollisionManager.mainPlayer.GetInteractObject() != null)
        {
            if (Input.GetKey(InputHandler.input.interact))
            {
                PlayerCollisionManager.mainPlayer.GetInteractObject().BehaveInteraction();
            }
        }
    }

    public void ShowInventory()
    {
        if (Input.GetKey(InputHandler.input.showInventory) && !showInventoryProcessed)
        {
            if (EvidenceInventory.inventory.GetActivated())
            {
                EvidenceInventory.inventory.SetActivated(false);
            }
            else
            {
                EvidenceInventory.inventory.SetActivated(true);
            }
            showInventoryProcessed = true;
        }
    }

    public void ProcessAllower()
    {
        if (Input.GetKeyUp(InputHandler.input.showInventory))
            showInventoryProcessed = false;
    }

    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public void Behave() // Singleton class (Anotacion)
    {
        if (InputHandler.input.inputDetected())
        {
            if (TextBox.textBox.GetActivated() == false &&
                EvidenceInventory.inventory.GetActivated() == false &&
                ElectionBox.electionBox.GetActivated() == false)
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
        Behave();
    }
}
