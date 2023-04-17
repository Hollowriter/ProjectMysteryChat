using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAlgorithm : SceneAlgorithm
{
    [SerializeField] private PointToFollow[] pointsToFollow;
    [SerializeField] private GameObject actCharacter;
    [SerializeField] private bool isPlayerActCharacter;
    private CharacterAnimationsManager animationsManagerCharacter;
    [SerializeField] private float characterSpeed;
    int pointsFollowed;

    void Begin() 
    {
        followPoints = pointsToFollow;
        if (!isPlayerActCharacter)
        {
            character = actCharacter;
            animationsManagerCharacter = character.GetComponent<CharacterAnimationsManager>();
        }
        else
        {
            character = PlayerMovement.instance.gameObject;
        }
        pointsFollowed = 0;
    }

    private void Awake()
    {
        Begin();
    }

    void FollowPoint()
    {
        if (!followPoints[pointsFollowed].dontMove)
        {
            float step = characterSpeed * Time.deltaTime;
            character.transform.position = Vector3.MoveTowards(character.transform.position, followPoints[pointsFollowed].gameObject.transform.position, step);
        }
    }

    void CheckPositionToChange()
    {
        if (!isPlayerActCharacter)
            animationsManagerCharacter.ChangeCharacterPosition(followPoints[pointsFollowed].positionToChange);
        /*else
            PlayerAnimations.instance*/
    }

    void CheckToChangePoint() 
    {
        if ((followPoints[pointsFollowed].gameObject.transform.position - character.transform.position).magnitude < 0.25f || followPoints[pointsFollowed].dontMove)
        {
            if (pointsFollowed < followPoints.Length - 1)
            {
                pointsFollowed++;
            }
            else 
            {
                SetAlgorithmEnd(true);
            }
        }
    }

    public override void ActScript()
    {
        CheckPositionToChange();
        FollowPoint();
        CheckToChangePoint();
    }
}
