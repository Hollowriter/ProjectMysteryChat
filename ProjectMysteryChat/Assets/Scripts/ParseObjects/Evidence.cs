using UnityEngine;

[System.Serializable]
public class Evidence
{
    public string Item;
    public string Description;
}

[System.Serializable]
public class EvidenceCollection
{
    public Evidence[] Evidence;
}
