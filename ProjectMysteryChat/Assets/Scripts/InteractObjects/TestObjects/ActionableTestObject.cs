using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionableTestObject : InteractObject
{
    public override void NearPlayer()
    {
        Debug.Log("I'm just near him");
    }

    public override void BehaveInteraction()
    {
        Debug.Log("I function");
    }
}
