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

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        speechIndex = 0;
        textWriting = false;
        textWritten = false;
        dialogueText.text = "";
        dialogSetted = "";
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

    void CheckElections()
    {
        if (speechIndex >= items.Dialogs.Length)
        {
            ElectionBox.instance.SetActivated(true);
        }
    }

    void CheckAnswers()
    {
        if (speechIndex >= items.Dialogs.Length)
        {
            AnswerInspector.instance.SetActivated(true);
            PresentButton.instance.SetActivated(true);
        }
    }

    void Next()
    {
        if (textWritten == true && EvidenceInventory.instance.GetActivated() == false)
        {
            if (GUILayout.Button("Next"))
            {
                this.speechIndex++;
                dialogueText.text = "";
                textWritten = false;
                textWriting = false;
                CheckElections();
                CheckAnswers();
            }
        }
    }

    public void SetDialog(string dialogFileName)
    {
        dialogSetted = dialogFileName;
        speechIndex = 0;
        dialogueText.text = "";
        textWritten = false;
        textWriting = false;
        string fileName = Application.streamingAssetsPath + "/Dialogs/" + dialogFileName;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string json = reader.ReadToEnd();
            items = JsonUtility.FromJson<DialogCollection>(json);
            ElectionBox.instance.SetElections(JsonUtility.FromJson<ElectionCollection>(json));
            AnswerInspector.instance.SetAnswers(JsonUtility.FromJson<AnswerCollection>(json));
        }
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
