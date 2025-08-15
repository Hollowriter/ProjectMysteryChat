using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : SingletonBase<PlayerInteractions>
{
    bool interactionPressed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetActivated(true);
        interactionPressed = false;
    }

    private void InteractObject()
    {
        if (PlayerCollisionManager.instance.GetInteractObject() != null && !PauseManager.instance.Paused())
        {
            if (Input.GetKey(InputHandler.instance.interact) && !interactionPressed)
            {
                PlayerCollisionManager.instance.GetInteractObject().BehaveInteraction();
                interactionPressed = true;
            }
        }
        else if (Input.GetKey(InputHandler.instance.interact) && !interactionPressed)
        {
            interactionPressed = true;
        }

        if (Input.GetKeyUp(InputHandler.instance.interact))
        {
            interactionPressed = false;
        }
    }

    private void InteractionProcessAllower()
    {
        interactionPressed = false;
    }

    protected override void BehaveSingleton()
    {
        if (InputHandler.instance.inputDetected())
        {
            InteractObject();
            return;
        }
        InteractionProcessAllower();
    }

    void Update()
    {
        BehaveSingleton();
    }
}
