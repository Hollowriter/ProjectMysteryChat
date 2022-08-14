using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneObject : InteractObject
{
    List<SceneAlgorithm> scenes;

    protected override void Begin() 
    {
        base.Begin();
        scenes = new List<SceneAlgorithm>();
        for (int i = 0; i < this.gameObject.GetComponentsInChildren<SceneAlgorithm>().Length; i++)
        {
            scenes.Add(this.gameObject.GetComponentsInChildren<SceneAlgorithm>()[i]);
        }
    }

    private void Start()
    {
        Begin();
    }

    public override void NearPlayer()
    {
        if (IShouldBeActive())
        {
            CutsceneManager.instance.SetCutscenes(scenes);
            SetPermanentInteraction(); // This should work differently. (Hollow)
        }
    }
}
