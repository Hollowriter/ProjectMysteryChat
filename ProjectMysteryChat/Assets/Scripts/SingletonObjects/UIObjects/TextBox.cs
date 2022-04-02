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
    int textSlowDown;
    DialogCollection items;
    string dialogSetted;
    GameObject nextButton;

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
    }

    private void Awake()
    {
        SingletonAwake();
    }

    protected override bool ConditionsToBeActive()
    {
        if (items != null && GetActivated())
        {
            if (speechIndex < items.Dialogs.Length)
            {
                return GetActivated();
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

    void Next()
    {
        if (textWritten == true && EvidenceInventory.instance.GetActivated() == false)
        {
            if (nextButton == null)
                nextButton = ButtonCreator.instance.CreateButton("Next", this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            else
                nextButton.SetActive(true);
            if (GUILayout.Button("Next")) // Replace this with a next button from the button generator. (Hollow)
            {
                this.speechIndex++;
                WipeTextBox();
            }
        }
    }

    void CheckOnDocumentManager()
    {
        if (speechIndex >= items.Dialogs.Length)
        {
            DocumentManager.instance.CheckElectionsAndInspector();
        }
    }

    public void SetDialog(DialogCollection dialogs)
    {
        items = dialogs;
        speechIndex = 0;
    }

    public string GetDialogSetted()
    {
        return dialogSetted;
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            WriteText();
            Next();
            CheckOnDocumentManager();
        }
    }

    private void OnGUI()
    {
        BehaveSingleton();
    }

    IEnumerator DialogTyping(string _word)
    {
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
