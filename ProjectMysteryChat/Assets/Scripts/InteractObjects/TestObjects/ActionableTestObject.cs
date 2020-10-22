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
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            Debug.Log("I function");
        }
    }
}
