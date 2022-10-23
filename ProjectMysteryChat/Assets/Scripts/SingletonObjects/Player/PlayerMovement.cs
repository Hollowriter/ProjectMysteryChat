using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SingletonBase<PlayerMovement>
{
    [SerializeField]
    private int playerSpeed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
    }

    private void Awake()
    {
        SingletonAwake();
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

    public void ChangePlayerPosition(float newPlayerPositionX, float newPlayerPositionY)
    {
        this.gameObject.transform.position = new Vector3(newPlayerPositionX, newPlayerPositionY, PlayerMovement.instance.gameObject.transform.position.z);
    }

    public int GetPlayerSpeed()
    {
        return playerSpeed;
    }

    protected override void BehaveSingleton()
    {
        if (InputHandler.instance.inputDetected())
        {
            MovementKeys();
        }
    }

    void Update()
    {
        BehaveSingleton();
    }
}
