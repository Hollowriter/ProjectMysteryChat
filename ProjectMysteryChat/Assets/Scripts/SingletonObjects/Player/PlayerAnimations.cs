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

    void WalkingAnimations() 
    {
        if (Input.GetKey(InputHandler.instance.walkUp))
        {
            this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 1);
            this.gameObject.GetComponentInChildren<Animator>().SetBool("Moving", true);
        }
        if (Input.GetKey(InputHandler.instance.walkDown))
        {
            this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 0);
            this.gameObject.GetComponentInChildren<Animator>().SetBool("Moving", true);
        }
        if (Input.GetKey(InputHandler.instance.walkLeft))
        {
            this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 2);
            this.gameObject.GetComponentInChildren<Animator>().SetBool("Moving", true);
        }
        if (Input.GetKey(InputHandler.instance.walkRight))
        {
            this.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 3);
            this.gameObject.GetComponentInChildren<Animator>().SetBool("Moving", true);
        }
        if (!Input.GetKey(InputHandler.instance.walkUp) && !Input.GetKey(InputHandler.instance.walkDown) 
            && !Input.GetKey(InputHandler.instance.walkLeft) && !Input.GetKey(InputHandler.instance.walkRight))
        {
            this.gameObject.GetComponentInChildren<Animator>().SetBool("Moving", false);
        }
    }

    protected override void BehaveSingleton()
    {
        base.BehaveSingleton();
        WalkingAnimations();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
