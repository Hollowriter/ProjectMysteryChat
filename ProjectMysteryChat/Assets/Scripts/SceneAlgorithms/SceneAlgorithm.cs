using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneAlgorithm : MonoBehaviour
{
    bool algorithmEnd = false;
    protected string[] dialogFiles;
    protected GameObject[] followPoints;
    protected GameObject character;

    public void SetAlgorithmEnd(bool _algorithmEnd) 
    {
        algorithmEnd = _algorithmEnd;
    }

    public bool GetAlgorithmEnd() 
    {
        return algorithmEnd;
    }

    public abstract void ActScript();
}
