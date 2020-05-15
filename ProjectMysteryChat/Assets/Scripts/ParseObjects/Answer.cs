using UnityEngine;

[System.Serializable]
public class Answer
{
    public string ExpectedAnswer;
    public string CorrectDialog;
    public string WrongDialog;
}

[System.Serializable]
public class AnswerCollection
{
    public Answer[] Answers;
}