using UnityEngine;

[System.Serializable]
public class Transition
{
    public string Type;
    public string Name;
}

[System.Serializable]
public class LoneTransition
{
    public Transition[] Transition;
}
