using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : SingletonBase<TextBox>
{
    char letter;
    int speechIndex;
    bool textWriting;
    bool textWritten;
    [SerializeField]
    Text dialogueText;
    [SerializeField]
    GameObject dialogueBackground;
    [SerializeField]
    int textSlowDown;
    DialogCollection items;
    string dialogSetted;
    GameObject nextButton;
    GameObject nextDebateButton;
    GameObject previousDebateButton;
    [SerializeField]
    Transform nextDebateButtonLocation;
    [SerializeField]
    Transform prevDebateButtonLocation;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        speechIndex = 0;
        textWriting = false;
        textWritten = false;
        dialogueText.text = "";
        dialogSetted = "";
        nextButton = null;
        if (dialogueBackground != null)
            dialogueBackground.SetActive(false);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    protected override bool ConditionsToBeActive()
    {
        if (items != null && GetActivated())
        {
            if (items.Dialogs != null)
            {
                if (speechIndex < items.Dialogs.Length)
                {
                    return GetActivated();
                }
            }
        }
        SetActivated(false);
        return GetActivated();
    }

    void WriteText()
    {
        if (textWriting == false)
        {
            StopAllCoroutines();
            if (speechIndex < items.Dialogs.Length)
            {
                StartCoroutine(DialogTyping(this.items.Dialogs[this.speechIndex].Text));
            }
            textWriting = true;
        }
    }

    void WipeTextBox()
    {
        dialogueText.text = "";
        textWritten = false;
        textWriting = false;
    }

    void NextButtonAppear()
    {
        if (textWritten == true && EvidenceInventory.instance.GetActivated() == false)
        {
            if (nextButton == null)
            {
                nextButton = ButtonCreator.instance.CreateButton("Next", this.gameObject.transform.position.x, this.gameObject.transform.position.y);
                nextButton.GetComponent<Button>().onClick.AddListener(NextPressed);
                nextButton.GetComponent<Button>().onClick.AddListener(PortraitBoxes.instance.ContinuousNextImage);
            }
            else
            {
                nextButton.SetActive(true);
            }
        }
    }

    void CheckOnDocumentManager()
    {
        if (speechIndex >= items.Dialogs.Length)
        {
            DocumentManager.instance.CheckElectionsAndInspector();
            dialogueBackground.SetActive(false); // Check to improve this. (Hollow)
        }
    }

    void DebateButtonsAppear() 
    {
        if (textWritten == true && EvidenceInventory.instance.GetActivated() == false)
        {
            if (nextDebateButton == null && this.speechIndex < items.Dialogs.Length - 1)
            {
                nextDebateButton = ButtonCreator.instance.CreateButton(">", nextDebateButtonLocation.position.x, nextDebateButtonLocation.position.y);
                nextDebateButton.GetComponent<Button>().onClick.AddListener(NextDebateButtonPressed);
                nextDebateButton.GetComponent<Button>().onClick.AddListener(PortraitBoxes.instance.NextImage);
            }
            else if (this.speechIndex < items.Dialogs.Length - 1)
            {
                nextDebateButton.SetActive(true);
            }
            if (previousDebateButton == null && this.speechIndex > 0)
            {
                previousDebateButton = ButtonCreator.instance.CreateButton("<", nextDebateButtonLocation.position.x, nextDebateButtonLocation.position.y);
                previousDebateButton.GetComponent<Button>().onClick.AddListener(PreviousDebateButtonPressed);
                previousDebateButton.GetComponent<Button>().onClick.AddListener(PortraitBoxes.instance.PreviousImage);
            }
            else if (this.speechIndex > 0)
            {
                previousDebateButton.SetActive(true);
            }
        }
    }

    public void SetDialog(DialogCollection dialogs)
    {
        items = dialogs;
    }

    public void ResetSpeechIndex()
    {
        speechIndex = 0;
    }

    public string GetDialogSetted()
    {
        return dialogSetted;
    }

    public void SetNextButtonActive(bool activate)
    {
        if (nextButton != null)
        {
            if (dialogueText.text != "" && dialogueText.text != null)
                nextButton.SetActive(activate);
            else
                nextButton.SetActive(false);
        }
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            WriteText();
            if (items.IsDebate)
            {
                DebateButtonsAppear();
            }
            else
            {
                NextButtonAppear();
            }
        }
    }

    private void OnGUI()
    {
        BehaveSingleton();
    }

    void NextPressed()
    {
        this.speechIndex++;
        WipeTextBox();
        nextButton.SetActive(false);
        CheckOnDocumentManager();
    }

    void NextDebateButtonPressed() 
    {
        this.speechIndex++;
        if (this.speechIndex < items.Dialogs.Length)
        {
            WipeTextBox();
            if (nextDebateButton != null)
                nextDebateButton.SetActive(false);
            if (previousDebateButton != null)
                previousDebateButton.SetActive(false);
        }
        else 
        {
            this.speechIndex = items.Dialogs.Length - 1;
        }
    }

    void PreviousDebateButtonPressed()
    {
        this.speechIndex--;
        if (this.speechIndex >= 0)
        {
            WipeTextBox();
            if (nextDebateButton != null)
                nextDebateButton.SetActive(false);
            if (previousDebateButton != null)
                previousDebateButton.SetActive(false);
        }
        else
        {
            this.speechIndex = 0;
        }
    }

    IEnumerator DialogTyping(string _word)
    {
        if (!dialogueBackground.activeInHierarchy)
            dialogueBackground.SetActive(true);
        int typingIndex = 0;
        dialogueText.text = "";
        foreach (char letter in _word.ToCharArray())
        {
            dialogueText.text += letter;
            Thread.Sleep(textSlowDown);
            typingIndex++;
            if (typingIndex >= _word.ToCharArray().Length)
            {
                textWritten = true;
            }
            yield return null;
        }
    }
}
