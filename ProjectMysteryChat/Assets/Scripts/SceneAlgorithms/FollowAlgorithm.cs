using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlgorithm : SceneAlgorithm
{
    public PointToFollow[] pointsToFollow;
    public GameObject actCharacter;
    CharacterAnimationsManager animationsManagerCharacter;
    public float characterSpeed;
    int pointsFollowed;

    void Begin() 
    {
        followPoints = pointsToFollow;
        character = actCharacter;
        animationsManagerCharacter = actCharacter.GetComponent<CharacterAnimationsManager>();
        pointsFollowed = 0;
    }

    private void Awake()
    {
        Begin();
    }

    void FollowPoint()
    {
        float step = characterSpeed * Time.deltaTime;
        character.transform.position = Vector3.MoveTowards(character.transform.position, followPoints[pointsFollowed].gameObject.transform.position, step);
    }

    void CheckPositionToChange()
    {
        animationsManagerCharacter.ChangeCharacterPosition(followPoints[pointsFollowed].positionToChange);
    }

    void CheckToChangePoint() 
    {
        if ((followPoints[pointsFollowed].gameObject.transform.position - character.transform.position).magnitude < 0.25f)
        {
            if (pointsFollowed < followPoints.Length - 1)
            {
                pointsFollowed++;
            }
            else 
            {
                animationsManagerCharacter.SetMoving(false);
                SetAlgorithmEnd(true);
            }
        }
    }

    public override void ActScript()
    {
        animationsManagerCharacter.SetMoving(true);
        FollowPoint();
        CheckToChangePoint();
        CheckPositionToChange();
    }
}
