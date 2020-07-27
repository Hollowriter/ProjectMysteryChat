using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneAlgorithm : MonoBehaviour
{
    public string[] dialogFiles;
    public GameObject[] followPoints;
    public GameObject[] characters;
    public abstract void ActScript();
}
