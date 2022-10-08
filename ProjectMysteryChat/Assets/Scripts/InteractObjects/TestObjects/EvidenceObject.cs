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
        IShouldExist();
        SetTextToBox();
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            ShowText();
            this.gameObject.SetActive(false);
        }
    }
}
