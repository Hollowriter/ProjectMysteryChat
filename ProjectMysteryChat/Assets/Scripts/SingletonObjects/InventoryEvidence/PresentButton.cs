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
        presentButton = this.GetComponent<Button>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    protected override bool ConditionsToBeActive()
    {
        if (GetActivated())
        {
            return GetActivated();
        }
        SetActivated(false);
        return GetActivated();
    }

    public void Pressed()
    {
        AnswerInspector.instance.CheckAnswer();
    }
}
