using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerInspector : SingletonBase<AnswerInspector>
{
    AnswerCollection answers;
    string evidenceName;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
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

    public void SetAnswers(AnswerCollection _answers)
    {
        answers = _answers;
    }

    public void SetEvidenceToCheck(string _evidenceName)
    {
        evidenceName = _evidenceName;
    }

    public void CheckAnswer()
    {
        for (int i = 0; i < answers.Answers.Length; i++)
        {
            if (evidenceName == answers.Answers[i].ExpectedAnswer)
            {
                TextBox.instance.SetDialog(answers.Answers[i].CorrectDialog);
                TextBox.instance.SetActivated(true);
                PresentButton.instance.SetActivated(false);
                EvidenceInventory.instance.SetActivated(false);
                ElectionBox.instance.SetActivated(false);
                SetActivated(false);
                return;
            }
        }
        TextBox.instance.SetDialog(answers.Answers[0].WrongDialog);
        TextBox.instance.SetActivated(true);
        PresentButton.instance.SetActivated(false);
        EvidenceInventory.instance.SetActivated(false);
        ElectionBox.instance.SetActivated(false);
        SetActivated(false);
    }
}
