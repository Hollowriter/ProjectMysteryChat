using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                playerAnimator.SetInteger("Position", 1);
            }
            if (Input.GetKey(InputHandler.instance.walkDown))
            {
                playerAnimator.SetInteger("Position", 0);
            }
            if (Input.GetKey(InputHandler.instance.walkLeft))
            {
                playerAnimator.SetInteger("Position", 2);
            }
            if (Input.GetKey(InputHandler.instance.walkRight))
            {
                playerAnimator.SetInteger("Position", 3);
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
