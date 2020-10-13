using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneObject : InteractObject
{
    List<SceneAlgorithm> scenes;

    void Begin() 
    {
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
        CutsceneManager.instance.SetCutscenes(scenes);
        SetPermanentInteraction();
    }
}
