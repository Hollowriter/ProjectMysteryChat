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
        //if (!AnswerInspector.instance.GetActivated() && !ElectionBox.instance.GetActivated() 
          //  && transition.Transition[0].Type == "Dialog")
        //{
            DocumentManager.instance.SetDocument(transition.Transition[0].Name);
            TextBox.instance.SetActivated(true);
            transition = null;
        // }
    }

    public void SendTransitionToLevelManager() 
    {
        LevelManager.instance.ChangeScene(transition.Transition[0].Name);
        transition = null;
    }

    public void CheckWhereToSendTransition() 
    {
        Debug.Log("CheckTransitionNotInsideYet");
        if (!AnswerInspector.instance.GetActivated() && !ElectionBox.instance.GetActivated()) 
        {
            Debug.Log("CheckWhereToSendTransition");
            switch (transition.Transition[0].Type) 
            {
                case "Dialog":
                    Debug.Log("SendTransitionToBox");
                    SendTransitionToBox();
                    break;
                case "Scene":
                    Debug.Log("SendTransitionToLevelManager");
                    SendTransitionToLevelManager();
                    break;
            }
            Debug.Log("EndFunction");
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
