using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
    [SerializeField]
    protected List<Number> numbers;
    [SerializeField]
    protected int answer;
    [SerializeField]
    private string solvedInteractionFileName;
    [SerializeField]
    PlotConditioned plotCondition;

    private void Awake()
    {
        this.gameObject.SetActive(IShouldBeActive());
    }

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

    private bool IShouldBeActive()
    {
        if (plotCondition != null)
        {
            /*if (!plotCondition.CheckCondition())
            {
                return false;
            }*/
        }
        return true;
    }

    private void PuzzleBehave()
    {
        if (CheckAnswer())
        {
            PuzzleSolved();
            return;
        }
    }

    private void PuzzleSolved()
    {
        DocumentManager.instance.SetDocument(solvedInteractionFileName);
    }
}
