using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public static TextBox textBox = null;
    char letter;
    int speechIndex;
    bool textWriting;
    bool textWritten;
    bool activated;
    [SerializeField]
    Text dialogueText;
    [SerializeField]
    int textSlowDown;
    DialogCollection items;

    private void Awake()
    {
        speechIndex = 0;
        textWriting = false;
        textWritten = false;
        activated = false;
        if (textBox == null)
        {
            textBox = this;
        }
        else if (textBox != this)
        {
            Destroy(gameObject);
        }
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

    void Next()
    {
        if (textWritten == true)
        {
            if (GUILayout.Button("Next"))
            {
                if (speechIndex < items.Dialogs.Length)
                {
                    this.speechIndex++;
                    if (speechIndex >= items.Dialogs.Length)
                    {
                        speechIndex = 0;
                        SetActivated(false);
                        ElectionBox.electionBox.SetActivate(true); // Motivo de testeo, esto despues se refactorea
                    }
                }
                dialogueText.text = "";
                textWritten = false;
                textWriting = false;
            }
        }
    }

    public void SetDialog(string dialogFileName)
    {
        string fileName = Application.streamingAssetsPath + "/Dialogs/" + dialogFileName;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string json = reader.ReadToEnd();
            items = JsonUtility.FromJson<DialogCollection>(json);
            ElectionBox.electionBox.SetElections(JsonUtility.FromJson<ElectionCollection>(json));
        }
    }

    public void SetActivated(bool _active)
    {
        activated = _active;
    }

    public bool GetActivated()
    {
        return activated;
    }

    void Behave()
    {
        if (activated)
        {
            WriteText();
            Next();
        }
    }

    private void OnGUI()
    {
        Behave();
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
