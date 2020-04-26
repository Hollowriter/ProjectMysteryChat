using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    void WriteText()
    {
        if (textWritten == false)
        {
            StopAllCoroutines();
            if (speechIndex < speech.Length)
            {
                StartCoroutine(DialogTyping(this.speech[this.speechIndex]));
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
                if (speechIndex < speech.Length)
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
