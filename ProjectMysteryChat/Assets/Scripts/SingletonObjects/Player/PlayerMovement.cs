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
        if (LevelManager.instance.GetSceneName() != "Menu")
        {
            if (!PauseManager.instance.Paused())
            {
                if (Input.GetKey(InputHandler.instance.walkUp) || Input.GetKey(InputHandler.instance.walkUpArrow))
                {
                    transform.position += (Vector3.up) * playerSpeed * Time.deltaTime;
                }
                if (Input.GetKey(InputHandler.instance.walkDown) || Input.GetKey(InputHandler.instance.walkDownArrow))
                {
                    transform.position += (Vector3.down) * playerSpeed * Time.deltaTime;
                }
                if (Input.GetKey(InputHandler.instance.walkLeft) || Input.GetKey(InputHandler.instance.walkLeftArrow))
                {
                    transform.position += (Vector3.left) * playerSpeed * Time.deltaTime;
                }
                if (Input.GetKey(InputHandler.instance.walkRight) || Input.GetKey(InputHandler.instance.walkRightArrow))
                {
                    transform.position += (Vector3.right) * playerSpeed * Time.deltaTime;
                }
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
