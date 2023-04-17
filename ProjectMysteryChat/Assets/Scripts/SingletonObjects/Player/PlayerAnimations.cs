using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPositionToLook
{
    Up = 1,
    Down = 0,
    Left = 2,
    Right = 3
}

public class PlayerAnimations : SingletonBase<PlayerAnimations>
{
    Animator playerAnimator;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
        playerAnimator = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void WalkingPositions() 
    {
        if (!PauseManager.instance.Paused())
        {
            if (Input.GetKey(InputHandler.instance.walkUp))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Up);
            }
            if (Input.GetKey(InputHandler.instance.walkDown))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Down);
            }
            if (Input.GetKey(InputHandler.instance.walkLeft))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Left);
            }
            if (Input.GetKey(InputHandler.instance.walkRight))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Right);
            }
        }
    }

    void MovingAnimation() 
    {
        if ((Input.GetKey(InputHandler.instance.walkUp) || Input.GetKey(InputHandler.instance.walkDown)
            || Input.GetKey(InputHandler.instance.walkLeft) || Input.GetKey(InputHandler.instance.walkRight)) && !PauseManager.instance.Paused())
        {
            playerAnimator.SetBool("Moving", true);
        }
        else 
        {
            playerAnimator.SetBool("Moving", false);
        }
    }

    public void ChangePlayerDirection()

    protected override void BehaveSingleton()
    {
        if (PauseManager.instance != null)
        {
            WalkingPositions();
            MovingAnimation();
        }
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
