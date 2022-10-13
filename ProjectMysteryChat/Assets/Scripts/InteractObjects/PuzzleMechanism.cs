using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanism : InteractObject
{
    [SerializeField]
    Number number;

    public override void BehaveInteraction()
    {
        number.IncreaseValue();
        Debug.Log("NUMBER " + number.GetValue());
    }
}
