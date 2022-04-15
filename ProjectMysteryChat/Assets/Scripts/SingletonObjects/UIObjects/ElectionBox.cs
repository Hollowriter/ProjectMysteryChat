using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectionBox : SingletonBase<ElectionBox>
{
    ElectionCollection elections;
    List<Button> buttons;
    public float separationOfButtons;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        buttons = new List<Button>();
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
        DitchListeners();
        DeactivateButtons();
        buttons.Clear();
    }

    public void ShowElections()
    {
        if (EvidenceInventory.instance.GetActivated() == false)
        {
            GameObject theButton;
            if (elections != null){
                if (elections.Elections != null){
                    for (int i = 0; i < elections.Elections.Length; i++)
                    {
                        theButton = ButtonCreator.instance.CreateButton(elections.Elections[i].CandidateName, this.gameObject.transform.position.x, (this.gameObject.transform.position.y + (i * separationOfButtons))); // Find better coordinates. (Hollow)
                        string candidate = elections.Elections[i].Candidate;
                        theButton.GetComponent<Button>().onClick.AddListener(delegate {SendElectionToTextBox(candidate);});
                        buttons.Add(theButton.GetComponent<Button>()); // NOTE: BUG REGARDING THE DEACTIVATION OF BUTTONS. (Hollow)
                        // TO DO: DESTROY THE BUTTONS AND DEACTIVATE THEM WHEN YOU OPEN THE EVIDENCE MENU. (Hollow)
                    }
                }
            }
        }
    }

    void DitchListeners()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }
    }

    void DeactivateButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            ShowElections();
        }
    }

    public void CallBehave()
    {
        BehaveSingleton();
    }
}
