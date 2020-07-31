using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlgorithm : SceneAlgorithm
{
    public GameObject[] pointsToFollow;
    public GameObject[] actCharacters;

    void Begin() 
    {
        followPoints = pointsToFollow;
        characters = actCharacters;
    }

    private void Awake()
    {
        Begin();
    }

    void FollowPoints() 
    {
        // Nota: necesito un algoritmo de pathfinding.
    }

    public override void ActScript()
    {

    }
}
