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
        DontDestroyOnLoad(gameObject);
        evidenceName = " ";
    }

    private void Awake()
    {
        SingletonAwake();
    }

    bool ThereAreAnswers()
    {
        if (answers != null)
        {
            if (answers.Answers != null)
            {
                if (answers.Answers.Length > 0)
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
            if (ThereAreAnswers())
            {
                return GetActivated();
            }
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

    void SendAnswerToTextBox(string sentAnswer)
    {
        DocumentManager.instance.SetDocument(sentAnswer);
        TextBox.instance.SetActivated(true);
        EvidenceInventory.instance.SetActivatedInventoryMembers(false);
        ElectionBox.instance.DeactivateButtons();
        ElectionBox.instance.SetActivated(false);
        SetActivated(false);
        answers = null;
    }

    public void CheckAnswer()
    {
        if (ConditionsToBeActive())
        {
            for (int i = 0; i < answers.Answers.Length; i++)
            {
                if (evidenceName == answers.Answers[i].ExpectedAnswer)
                {
                    SendAnswerToTextBox(answers.Answers[i].CorrectDialog);
                    return;
                }
            }
            SendAnswerToTextBox(answers.Answers[0].WrongDialog);
        }
    }

    protected override void BehaveSingleton()
    {
        ConditionsToBeActive();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
