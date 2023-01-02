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
    { // Use when animations are available. (Hollow)
        /*if (IShouldBeActive())
        {
            SetTextToBox();
        }*/
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            SetTextToBox();
            ShowText();
        }
    }
}
