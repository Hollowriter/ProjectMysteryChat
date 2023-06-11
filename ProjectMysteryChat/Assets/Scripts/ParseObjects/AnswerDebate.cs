using UnityEngine;

[System.Serializable]
public class AnswerDebate
{
    public string ExpectedAnswer;
    public int ExpectedIndex;
    public string CorrectDialog;
    public string WrongDialog;
}

[System.Serializable]
public class AnswerDebateCollection
{
    public AnswerDebate[] AnswersDebate;
}
