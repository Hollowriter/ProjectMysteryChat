using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceTestObject : InteractObject
{
    public override void NearPlayer()
    {
        SetTextToBox();
    }

    public override void BehaveInteraction()
    {
        ShowText();
        SetEvidenceToInventory();
    }
}
