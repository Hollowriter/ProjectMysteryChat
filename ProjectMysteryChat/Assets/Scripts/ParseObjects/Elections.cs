using UnityEngine;

[System.Serializable]
public class Elections
{
    public string Candidate;
    public string CandidateName;
}

[System.Serializable]
public class ElectionCollection
{
    public Elections[] Elections;
}
