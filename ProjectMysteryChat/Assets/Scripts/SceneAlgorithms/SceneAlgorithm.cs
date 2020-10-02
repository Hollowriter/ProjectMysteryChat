using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneAlgorithm : MonoBehaviour
{
    bool algorithmEnd = false;
    protected string[] dialogFiles;
    protected GameObject[] followPoints;
    protected GameObject character;
    public bool withOtherAlgorithm; // Nota: Chequea si es una cutscene que se lee al mismo tiempo con otra.

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
