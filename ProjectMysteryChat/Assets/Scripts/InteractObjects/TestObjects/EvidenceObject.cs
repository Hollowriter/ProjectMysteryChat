using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceObject : InteractObject
{
    protected override void Begin()
    {
        base.Begin();
    }

    private void Awake()
    {
        Begin();
    }

    public override void NearPlayer()
    {
        // SetTextToBox();
        // Use this function when animations are available. (Hollow)
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            SetTextToBox();
            ShowText();
            this.gameObject.SetActive(false);
        }
    }
}
