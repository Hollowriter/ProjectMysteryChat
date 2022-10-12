using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsManager : MonoBehaviour
{
    Animator characterAnimator;
    public PositionToLook startPosition;
    string currentTrigger;
    PlotConditioned plotConditioned;

    void Awake()
    {
        plotConditioned = this.gameObject.GetComponent<PlotConditioned>();
    }

    void Start()
    {
        this.gameObject.SetActive(CheckExistance());
        characterAnimator = this.gameObject.GetComponentInChildren<Animator>();
        characterAnimator.SetTrigger(startPosition.ToString());
        currentTrigger = startPosition.ToString();
    }

    private bool CheckExistance()
    {
        if (plotConditioned != null)
        {
            return plotConditioned.CheckCondition();
        }
        return true;
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
