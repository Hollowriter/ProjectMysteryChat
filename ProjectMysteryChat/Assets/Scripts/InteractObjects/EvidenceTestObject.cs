using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceTestObject : InteractObject
{
    private void Awake()
    {
        IShouldExist(); // Interacciones (Testear)
    }

    public override void NearPlayer()
    {
        SetTextToBox();
    }

    public override void BehaveInteraction()
    {
        ShowText();
        SetPermanentInteraction(); // Interacciones (testear)
        SetEvidenceToInventory();
    }
}
