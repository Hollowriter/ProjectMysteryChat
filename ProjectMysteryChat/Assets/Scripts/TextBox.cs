using System.Collections;
using System.Collections.Generic;
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

    private void OnGUI()
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

    IEnumerator DialogTyping(string _word)
    {
        dialogueText.text = "";
        foreach (char letter in _word.ToCharArray())
        {
            dialogueText.text += letter;
            Debug.Log("entro");
            yield return null;
        }
    }
}
