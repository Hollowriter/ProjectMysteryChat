using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlgorithm : SceneAlgorithm
{
    public GameObject[] pointsToFollow; // Puntos que debe seguir-
    public GameObject[] actCharacters; // Personajes que deben seguir dichos puntos.

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
