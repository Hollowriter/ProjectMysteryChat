using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneAlgorithm : MonoBehaviour
{
    int pointsPassed = 0;
    int interactionFilesCompleted = 0;
    public abstract void ActScript(string[] interactionFiles, GameObject[] pointsToGo, GameObject character);
}
