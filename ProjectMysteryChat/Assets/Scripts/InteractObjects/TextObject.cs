using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : InteractObject
{
    private void Awake()
    {
        Begin();
    }

    public override void NearPlayer()
    {
        if (IShouldBeActive())
        {
            SetTextToBox();
        }
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            ShowText();
        }
    }
}
