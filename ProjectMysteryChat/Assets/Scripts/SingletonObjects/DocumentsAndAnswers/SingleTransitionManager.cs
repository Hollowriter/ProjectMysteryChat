﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTransitionManager : SingletonBase<SingleTransitionManager>
{
    LoneTransition transition;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        transition = null;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    bool ThereAreTransitions()
    {
        if (transition != null)
        {
            if (transition.Transition != null)
            {
                if (transition.Transition.Length > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    protected override bool ConditionsToBeActive()
    {
        if (GetActivated())
        {
            if (ThereAreTransitions())
            {
                return GetActivated();
            }
        }
        SetActivated(false);
        return GetActivated();
    }

    public void SetTransition(LoneTransition _transition)
    {
        transition = _transition;
    }

    public LoneTransition GetTransition()
    {
        return transition;
    }

    public void SendTransitionToBox()
    {
        if (!AnswerInspector.instance.GetActivated() && !ElectionBox.instance.GetActivated())
        {
            DocumentManager.instance.SetDocument(transition.Transition[0].Dialog);
            TextBox.instance.SetActivated(true);
            transition = null;
        }
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            SendTransitionToBox();
        }
    }

    private void Update()
    {
        BehaveSingleton();
    }
}