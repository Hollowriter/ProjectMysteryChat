using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : InteractObject
{
    SceneAlgorithm algorithm;
    public int arrayOfPointsSize;
    public int arrayOfInteractionFiles;
    public GameObject[] pointsToGo;
    public string[] cutSceneInteractionFiles;

    public void SetAlgorithm(SceneAlgorithm _algorithm) 
    {
        algorithm = _algorithm;
    }

    public SceneAlgorithm GetAlgorithm() 
    {
        return algorithm;
    }

    public virtual void ActScript() 
    {
        algorithm.ActScript(cutSceneInteractionFiles, pointsToGo, this.gameObject);
    }
}
