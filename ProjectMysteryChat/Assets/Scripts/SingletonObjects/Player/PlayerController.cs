using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int playerSpeed;
    public static PlayerController mainPlayer = null;

    private void Awake()
    {
        if (mainPlayer == null)
        {
            DontDestroyOnLoad(gameObject);
            mainPlayer = this;
        }
        else if (mainPlayer != this)
        {
            Destroy(gameObject);
        }
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

    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public void Behave()
    {
        if (TextBox.textBox.GetActivated() == false)
        {
            if (InputHandler.input.inputDetected())
            {
                MovementKeys();
                InteractObject();
            }
        }
    }

    void Update()
    {
        Behave();
    }
}
