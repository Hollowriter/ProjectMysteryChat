using UnityEngine;

[System.Serializable]
public class Dialogs
{
    public string Text;
}

[System.Serializable]
public class DialogCollection
{
    public Dialogs[] Dialogs; // convertir en un scriptable object. (Hollow)
    public bool IsDebate;
}
