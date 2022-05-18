using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsManager : MonoBehaviour
{
    Animator characterAnimator;
    public PositionToLook startPosition;
    string currentTrigger;

    void Start()
    {
        characterAnimator = this.gameObject.GetComponentInChildren<Animator>();
        characterAnimator.SetTrigger(startPosition.ToString());
        currentTrigger = startPosition.ToString();
    }

    public void ChangeCharacterPosition(PositionToLook position)
    {
        if (currentTrigger != position.ToString())
        {
            characterAnimator.SetTrigger(position.ToString());
            currentTrigger = position.ToString();
        }
    }
}
