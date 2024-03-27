using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerInspector : SingletonBase<AnswerInspector>
{
    AnswerCollection answers;
    AnswerDebateCollection answersDebate;
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
        if (answersDebate != null) 
        {
            if (answersDebate.AnswersDebate != null) 
            {
                if (answersDebate.AnswersDebate.Length > 0) 
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
                InventoryInstruction.instance.activateNotedElement?.Invoke(); // Optimize this later. (Hollow)
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

    public void SetDebateAnswers(AnswerDebateCollection _answers) 
    {
        answersDebate = _answers;
    }

    public void SetEvidenceToCheck(string _evidenceName)
    {
        evidenceName = _evidenceName;
    }

    public bool IsDebateInspection() 
    {
        if (answersDebate != null)
        {
            if (answersDebate.AnswersDebate != null)
            {
                if (answersDebate.AnswersDebate.Length > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void SendAnswerToTextBox(string sentAnswer)
    {
        DocumentManager.instance.SetDocument(sentAnswer);
        TextBox.instance.SetActivated(true);
        EvidenceInventory.instance.SetActivatedInventoryMembers(false);
        ElectionBox.instance.DeactivateButtons();
        ElectionBox.instance.SetActivated(false);
        PortraitBoxes.instance.PutOnImage();
        InventoryInstruction.instance.deactivateNotedElement?.Invoke(); // Optimize this later. (Hollow)
        SetActivated(false);
        answers = null;
    }

    public void CheckAnswer()
    {
        if (answers != null)
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

    public void CheckDebateAnswer() 
    {
        if (answersDebate != null) 
        {
            for (int i = 0; i < answersDebate.AnswersDebate.Length; i++)
            {
                if (evidenceName == answersDebate.AnswersDebate[i].ExpectedAnswer && TextBox.instance.GetSpeechIndex() == answersDebate.AnswersDebate[i].ExpectedIndex)
                {
                    SendAnswerToTextBox(answersDebate.AnswersDebate[i].CorrectDialog);
                    return;
                }
            }
            SendAnswerToTextBox(answersDebate.AnswersDebate[0].WrongDialog);
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
