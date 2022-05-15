using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneAlgorithm : MonoBehaviour
{
    bool algorithmEnd = false;
    protected string dialogFile;
    protected PointToFollow[] followPoints;
    protected GameObject character;
    public bool withOtherAlgorithm;

    public void SetAlgorithmEnd(bool _algorithmEnd) 
    {
        algorithmEnd = _algorithmEnd;
    }

    public void SetWithOtherAlgorithm(bool _withOtherAlgorithm) 
    {
        withOtherAlgorithm = _withOtherAlgorithm;
    }

    public bool GetAlgorithmEnd() 
    {
        return algorithmEnd;
    }

    public bool GetWithOtherAlgorithm() 
    {
        return withOtherAlgorithm;
    }

    public abstract void ActScript();
}
