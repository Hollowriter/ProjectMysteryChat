using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceObject : InteractObject
{
    protected override void Begin()
    {
        base.Begin();
        IShouldExist();
    }

    private void Awake()
    {
        Begin();
    }

    public override void NearPlayer()
    {
        if (IShouldBeActive())
        {
            SetTextToBox();
            IShouldExist();
        }
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            ShowText();
            SetPermanentInteraction(); // This should work differently. (Hollow)
            Destroy(gameObject);
        }
    }
}
