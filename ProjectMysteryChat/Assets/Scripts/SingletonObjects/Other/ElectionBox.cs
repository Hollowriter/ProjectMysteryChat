using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectionBox : MonoBehaviour
{
    public static ElectionBox electionBox = null;
    ElectionCollection elections;
    bool activated;

    private void Awake()
    {
        activated = false;
        if (electionBox == null)
        {
            DontDestroyOnLoad(gameObject);
            electionBox = this;
        }
        else if (electionBox != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetElections(ElectionCollection newElections)
    {
        elections = newElections;
    }

    public void SetActivate(bool _activated)
    {
        activated = _activated;
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

    public void SendElectionToTextBox(string electionSelected)
    {
        TextBox.textBox.SetDialog(electionSelected);
        TextBox.textBox.SetActivated(true);
    }

    public void ShowElections()
    {
        if (activated)
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

    public void CheckToAutoDeactivate()
    {
        if (ElectionsEmpty())
        {
            activated = false;
        }
    }

    public bool GetActivated()
    {
        return activated;
    }

    void Behave()
    {
        if (activated)
        {
            CheckToAutoDeactivate();
            ShowElections();
        }
    }

    public void OnGUI()
    {
        Behave();
    }
}
