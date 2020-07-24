using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneAlgorithm : MonoBehaviour
{
    public abstract void ActScript(string[] interactionFiles, GameObject[] pointsToGo);
}
