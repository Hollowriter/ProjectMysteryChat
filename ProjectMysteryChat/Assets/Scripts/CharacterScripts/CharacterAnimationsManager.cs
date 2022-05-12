using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsManager : MonoBehaviour
{
    Animator characterAnimator;

    void Start()
    {
        characterAnimator = this.gameObject.GetComponentInChildren<Animator>();
    }

    public void ChangeCharacterPosition(int position)
    {
        characterAnimator.SetInteger("Position", position);
    }

    public void SetMoving(bool isMoving)
    {
        characterAnimator.SetBool("Moving", isMoving);
    }
}
