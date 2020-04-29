using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    InteractObject objectToInteract;
    public static PlayerCollisionManager mainPlayer = null;

    private void Awake()
    {
        if (mainPlayer == null)
        {
            DontDestroyOnLoad(gameObject);
            mainPlayer = this;
        }
        else if (mainPlayer != this)
        {
            Destroy(gameObject);
        }
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactuable")
        {
            CollideWithObject(other.gameObject.GetComponent<InteractObject>());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactuable")
        {
            StopCollideWithObject();
        }
    }
}
