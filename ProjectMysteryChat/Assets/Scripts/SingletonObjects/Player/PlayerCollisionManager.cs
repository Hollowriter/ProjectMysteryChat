using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : SingletonBase<PlayerCollisionManager>
{
    InteractObject objectToInteract;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        SetActivated(true);
    }

    private void Awake()
    {
        SingletonAwake();
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

    public InteractObject GetInteractObject()
    {
        return objectToInteract;
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Interactuable") 
        {
            SpaceInstruction.instance.activateElements?.Invoke();
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Interactuable") // The stay doesn't register while the player is not moving. (Hollow)
        {
            CollideWithObject(other.gameObject.GetComponent<InteractObject>());
        }
        if (other.tag == "Cutscene") 
        {
            other.gameObject.GetComponent<CutsceneObject>().NearPlayer();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Interactuable")
        {
            StopCollideWithObject();
        }
        SpaceInstruction.instance.deactivateElements?.Invoke();
    }
}
