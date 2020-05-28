using UnityEngine;

[System.Serializable]
public class Stage 
{
    public string SceneName;
    public string PositionX;
    public string PositionY;
}

[System.Serializable]
public class Interaction 
{
    public string InteractionName;
}

[System.Serializable]
public class InteractionCollection 
{
    public Interaction[] Interactions;
}

[System.Serializable]
public class SaveData
{
    public Stage StageSaved;
    public EvidenceCollection EvidenceSaved;
    public InteractionCollection InteractionsDone;
}
