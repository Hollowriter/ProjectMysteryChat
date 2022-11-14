using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
    [SerializeField]
    protected List<Number> numbers;
    [SerializeField]
    protected int answer;

    private void Start() 
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i].onChange += PuzzleBehave;
        }    
    }

    protected virtual bool CheckAnswer()
    {
        return false;
    }

    void PuzzleBehave()
    {
        if (CheckAnswer())
        {
            Debug.Log("PuzzleSolved");
            return;
        }
        Debug.Log("Wrong");
    }
}
