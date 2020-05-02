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

    public void ShowElections()
    {
        if (!ElectionsEmpty())
        {
            for (int i = 0; i < elections.Elections.Length; i++)
            {
                GUILayout.Button(elections.Elections[i].Candidate);
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

    public bool ElectionsEmpty()
    {
        if (elections.Elections.Length <= 0)
        {
            return true;
        }
        return false;
    }

    void Behave()
    {
        if (activated)
        {
            ShowElections();
            CheckToAutoDeactivate();
        }
    }

    public void OnGUI()
    {
        Behave();
    }
}
