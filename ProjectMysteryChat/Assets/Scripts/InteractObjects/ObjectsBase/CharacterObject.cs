using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : InteractObject
{
    SceneAlgorithm algorithm;

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
    }
}
