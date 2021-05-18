using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : SingletonBase<PlayerAnimations>
{
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

    void WalkingPositions() 
    {
        if (!PauseManager.instance.Paused())
        {
            if (Input.GetKey(InputHandler.instance.walkUp))
            {
                this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 1);
            }
            if (Input.GetKey(InputHandler.instance.walkDown))
            {
                this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 0);
            }
            if (Input.GetKey(InputHandler.instance.walkLeft))
            {
                this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 2);
            }
            if (Input.GetKey(InputHandler.instance.walkRight))
            {
                this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 3);
            }
        }
    }

    void MovingAnimation() 
    {
        if ((Input.GetKey(InputHandler.instance.walkUp) || Input.GetKey(InputHandler.instance.walkDown)
            || Input.GetKey(InputHandler.instance.walkLeft) || Input.GetKey(InputHandler.instance.walkRight)) && !PauseManager.instance.Paused())
        {
            this.gameObject.GetComponentInChildren<Animator>().SetBool("Moving", true);
        }
        else 
        {
            this.gameObject.GetComponentInChildren<Animator>().SetBool("Moving", false);
        }
    }

    protected override void BehaveSingleton()
    {
        WalkingPositions();
        MovingAnimation();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
