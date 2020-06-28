using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : InteractObject
{
    public override void NearPlayer()
    {
        SetTextToBox();
    }

    public override void BehaveInteraction()
    {
        ShowText();
    }
}
