using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCodePuzzle : CodePuzzle
{
    protected override bool CheckAnswer()
    {
        string checkNumbersInserted = null;
        for (int i = 0; i < numbers.Count; i++)
        {
            checkNumbersInserted += numbers[i].ToString();
        }
        int numbersConverted = int.Parse(checkNumbersInserted);
        return numbersConverted == answer;
    }
}
