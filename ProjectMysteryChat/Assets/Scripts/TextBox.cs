using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    string[] speech = new string[4] { "Hi", "How are you ?", "Nice weather today", "Want some ice cream ?" };
    char letter;
    int speechIndex = 0;
    bool textWritten = false;
    [SerializeField]
    Text dialogueText;
    [SerializeField]
    int textSlowDown;
    // JSON Dialogs
    [SerializeField]
    string dialogFileName;
    DialogCollection items;

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
                    return;
                }
                dialogueText.text = "";
                textWritten = false;
            }
        }
    }

    void Behave()
    {
        WriteText();
        Next();
    }

    // Para testear, borrar despues
    private void Awake()
    {
       string fileName = Application.streamingAssetsPath + "/Dialogs/" + dialogFileName;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string json = reader.ReadToEnd();
            items = JsonUtility.FromJson<DialogCollection>(json);
            Debug.Log(items.Dialogs.Length);
            for (int i = 0; i < items.Dialogs.Length; i++)
            {
                Debug.Log(items.Dialogs[i].Text);
            }
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
