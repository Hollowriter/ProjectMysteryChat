using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneObject : InteractObject
{
    public List<SceneAlgorithm> scenes;

    public override void NearPlayer()
    {
        CutsceneManager.instance.SetCutscenes(scenes);
        SetPermanentInteraction();
    }
}
