using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionableTestObject : InteractObject
{
    private void Awake()
    {
        Begin();
    }

    public override void NearPlayer()
    {
        if (IShouldBeActive())
        {
            Debug.Log("I'm just near him");
        }
        else
        {
            Debug.Log("I'm not active dude");
        }
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            Debug.Log("I function");
        }
    }
}
