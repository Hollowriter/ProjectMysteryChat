using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceObject : InteractObject
{
    private void Awake()
    {
        IShouldExist();
    }

    public override void NearPlayer()
    {
        SetTextToBox();
    }

    public override void BehaveInteraction()
    {
        ShowText();
        SetPermanentInteraction();
        Destroy(gameObject);
    }
}
