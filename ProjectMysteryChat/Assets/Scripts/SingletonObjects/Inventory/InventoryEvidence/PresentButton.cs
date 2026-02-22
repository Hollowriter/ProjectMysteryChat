using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentButton : SingletonBase<PresentButton>
{
    Button presentButton;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        presentButton = this.GetComponentInChildren<Button>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    protected override bool ConditionsToBeActive()
    {
        if (AnswerInspector.instance != null)
        {
            if (GetActivated() && AnswerInspector.instance.GetActivated())
            {
                return GetActivated();
            }
        }
        SetActivated(false);
        return GetActivated();
    }

    public void Pressed()
    {
        if (ConditionsToBeActive())
        {
            if (AnswerInspector.instance.IsDebateInspection())
            {
                AnswerInspector.instance.CheckDebateAnswer();
            }
            else
            {
                AnswerInspector.instance.CheckAnswer();
            }
        }
    }

    protected override void BehaveSingleton()
    {
        presentButton.gameObject.SetActive(ConditionsToBeActive());
    }

    private void OnGUI()
    {
        BehaveSingleton();
    }
}
