using System.Collections;
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
        DocumentManager.instance.SetDocument(transition.Transition[0].Name);
        TextBox.instance.SetActivated(true);
        transition = null;
    }

    public void SendTransitionToLevelManager() 
    {
        LevelManager.instance.ChangeScene(transition.Transition[0].Name);
        transition = null;
    }

    public void CheckWhereToSendTransition() 
    {
        switch (transition.Transition[0].Type) 
        {
            case "Dialog":
                SendTransitionToBox();
                break;
            case "Scene":
                SendTransitionToLevelManager();
                break;
        }
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            CheckWhereToSendTransition();
        }
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
