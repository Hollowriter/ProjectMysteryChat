using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlgorithm : SceneAlgorithm
{
    public GameObject[] pointsToFollow;
    public GameObject actCharacter;
    public float characterSpeed;
    int pointsFollowed;

    void Begin() 
    {
        followPoints = pointsToFollow;
        character = actCharacter;
        pointsFollowed = 0;
    }

    private void Awake()
    {
        Begin();
    }

    void FollowPoint()
    {
        float step = characterSpeed * Time.deltaTime;
        character.transform.position = Vector3.MoveTowards(character.transform.position, followPoints[pointsFollowed].transform.position, step);
    }

    void CheckToChangePoint() 
    {
        if ((followPoints[pointsFollowed].transform.position - character.transform.position).magnitude < 0.25f)
        {
            pointsFollowed++;
        }
    }

    public override void ActScript()
    {
        FollowPoint();
        CheckToChangePoint();
    }
}
