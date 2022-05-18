using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsManager : MonoBehaviour
{
    Animator characterAnimator;
    public PositionToLook startPosition;

    void Start()
    {
        characterAnimator = this.gameObject.GetComponentInChildren<Animator>();
        characterAnimator.SetTrigger(startPosition.ToString());
    }

    public void ChangeCharacterPosition(PositionToLook position)
    {
        characterAnimator.SetTrigger(position.ToString());
    }

    public void SetMoving(bool isMoving)
    {
        characterAnimator.SetBool("Moving", isMoving);
    }
}
