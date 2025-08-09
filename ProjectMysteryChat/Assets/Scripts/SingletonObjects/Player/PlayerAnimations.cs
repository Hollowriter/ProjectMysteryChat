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
            if (Input.GetKey(InputHandler.instance.walkUp) || Input.GetKey(InputHandler.instance.walkUpArrow))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Up);
            }
            if (Input.GetKey(InputHandler.instance.walkDown) || Input.GetKey(InputHandler.instance.walkDownArrow))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Down);
            }
            if (Input.GetKey(InputHandler.instance.walkLeft) || Input.GetKey(InputHandler.instance.walkLeftArrow))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Left);
            }
            if (Input.GetKey(InputHandler.instance.walkRight) || Input.GetKey(InputHandler.instance.walkRightArrow))
            {
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Right);
            }
        }
    }

    void MovingAnimation() 
    {
        if ((Input.GetKey(InputHandler.instance.walkUp) || Input.GetKey(InputHandler.instance.walkDown)
            || Input.GetKey(InputHandler.instance.walkUpArrow) || Input.GetKey(InputHandler.instance.walkDownArrow) ||
            Input.GetKey(InputHandler.instance.walkLeft) || Input.GetKey(InputHandler.instance.walkRight) ||
            Input.GetKey(InputHandler.instance.walkLeftArrow) || Input.GetKey(InputHandler.instance.walkRightArrow)) && !PauseManager.instance.Paused())
        {
            playerAnimator.SetBool("Moving", true);
        }
        else 
        {
            playerAnimator.SetBool("Moving", false);
        }
    }

    public void ChangePlayerDirection(PositionToLook positionToLook) 
    {
        switch (positionToLook) 
        {
            case PositionToLook.Down:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Down);
                playerAnimator.SetBool("Moving", false);
                break;
            case PositionToLook.DownMoving:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Down);
                playerAnimator.SetBool("Moving", true);
                break;
            case PositionToLook.Up:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Up);
                playerAnimator.SetBool("Moving", false);
                break;
            case PositionToLook.UpMoving:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Up);
                playerAnimator.SetBool("Moving", true);
                break;
            case PositionToLook.Left:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Left);
                playerAnimator.SetBool("Moving", false);
                break;
            case PositionToLook.LeftMoving:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Left);
                playerAnimator.SetBool("Moving", true);
                break;
            case PositionToLook.Right:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Right);
                playerAnimator.SetBool("Moving", false);
                break;
            case PositionToLook.RightMoving:
                playerAnimator.SetInteger("Position", (int)PlayerPositionToLook.Right);
                playerAnimator.SetBool("Moving", true);
                break;
        }
    }

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
