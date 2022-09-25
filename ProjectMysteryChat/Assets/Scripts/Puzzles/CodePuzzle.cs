using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
    [SerializeField]
    List<Number> numbers;
    [SerializeField]
    int answer;

    public virtual bool CheckAnswer()
    {
        return false;
    }
}
