using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int playerSpeed;

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

    public void Behave()
    {
        if (InputHandler.input.inputDetected())
        {
            MovementKeys();
        }
    }

    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    void Update()
    {
        Behave();
    }
}
