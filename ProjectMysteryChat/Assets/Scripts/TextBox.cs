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
        textWritten = false;
        activated = false;
        if (textBox == null)
        {
            DontDestroyOnLoad(gameObject);
            textBox = this;
        }
        else if (textBox != this)
        {
            Destroy(gameObject);
        }
    }

    void WriteText()
    {
        if (textWritten == false)
        {
            StopAllCoroutines();
            if (speechIndex < items.Dialogs.Length)
            {
                StartCoroutine(DialogTyping(this.items.Dialogs[this.speechIndex].Text));
            }
            textWritten = true;
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
                }
                else
                {
                    speechIndex = 0;
                    SetActivated(false); // fijarme si esto se puede hacer mejor
                    return;
                }
                dialogueText.text = "";
                textWritten = false;
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

    public void Behave()
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
        dialogueText.text = "";
        foreach (char letter in _word.ToCharArray())
        {
            dialogueText.text += letter;
            Thread.Sleep(textSlowDown);
            yield return null;
        }
    }
}

[System.Serializable]
public class Dialogs
{
    public string Text;
}

[System.Serializable]
public class DialogCollection
{
    public Dialogs[] Dialogs;
}
