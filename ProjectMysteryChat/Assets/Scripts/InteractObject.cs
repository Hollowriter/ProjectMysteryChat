using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    string dialogFileName;

    public void NearPlayer()
    {
        TextBox.textBox.SetDialog(dialogFileName);
    }

    public void ShowText()
    {
        TextBox.textBox.SetActivated(true);
    }
}
