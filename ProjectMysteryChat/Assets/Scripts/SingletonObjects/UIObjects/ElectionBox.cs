using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectionBox : SingletonBase<ElectionBox>
{
    ElectionCollection elections;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetElections(ElectionCollection newElections)
    {
        elections = newElections;
    }

    public bool ElectionsEmpty()
    {
        if (elections != null)
        {
            if (elections.Elections != null)
            {
                if (elections.Elections.Length > 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    protected override bool ConditionsToBeActive()
    {
        if (!ElectionsEmpty() && GetActivated())
        {
            return GetActivated();
        }
        SetActivated(false);
        return GetActivated();
    }

    public void SendElectionToTextBox(string electionSelected)
    {
        elections = null;
        DocumentManager.instance.SetDocument(electionSelected);
        TextBox.instance.SetActivated(true);
        AnswerInspector.instance.SetActivated(false);
        PresentButton.instance.SetActivated(false);
    }

    public void ShowElections()
    {
        if (EvidenceInventory.instance.GetActivated() == false)
        {
            for (int i = 0; i < elections.Elections.Length; i++)
            {
                if (GUILayout.Button(elections.Elections[i].CandidateName))
                {
                    SendElectionToTextBox(elections.Elections[i].Candidate);
                    return;
                }
            }
        }
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            ShowElections();
        }
    }

    public void OnGUI()
    {
        BehaveSingleton();
    }
}
