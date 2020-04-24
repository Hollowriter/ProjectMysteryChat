using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    string[] _speech = new string[4] { "Hi", "How are you ?", "Nice weather today", "Want some ice cream ?" };
    int _speechIndex = 0;
    private void OnGUI()
    {
        GUILayout.Label(this._speech[this._speechIndex]);
        if (GUILayout.Button("Next"))
            this._speechIndex++; // Todavia no esta terminado
    }
}
