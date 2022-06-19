using UnityEngine;

[System.Serializable]
public class Portraits
{
    public string CharacterLeft;
    public string ExpressionLeft;
    public string CharacterRight;
    public string ExpressionRight;
}

[System.Serializable]
public class PortraitCollection
{
    public Portraits[] Portraits;
}
