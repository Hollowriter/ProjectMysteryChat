using UnityEngine;

[System.Serializable]
public class Transition
{
    public string Type;
    public string Name;
    public string NewPlayerPositionX;
    public string NewPlayerPositionY;
}

[System.Serializable]
public class LoneTransition
{
    public Transition[] Transition;
}
