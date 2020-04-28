using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int playerSpeed;
    InteractObject objectToInteract;

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
        if (objectToInteract != null)
        {
            if (Input.GetKey(InputHandler.input.interact))
            {
                objectToInteract.ShowText();
            }
        }
    }

    public void CollideWithObject(InteractObject objectCollided)
    {
        objectToInteract = objectCollided;
        objectToInteract.NearPlayer();
    }

    public void StopCollideWithObject()
    {
        objectToInteract = null;
    }

    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public void Behave()
    {
        if (InputHandler.input.inputDetected())
        {
            MovementKeys();
            InteractObject();
        }
    }

    void Update()
    {
        Behave();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Interactuable")
        {
            CollideWithObject(other.gameObject.GetComponent<InteractObject>());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Interactuable")
        {
            StopCollideWithObject();
        }
    }
}
