using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
    [SerializeField]
    protected List<Number> numbers;
    [SerializeField]
    protected int answer;

    public virtual bool CheckAnswer()
    {
        return false;
    }
}
