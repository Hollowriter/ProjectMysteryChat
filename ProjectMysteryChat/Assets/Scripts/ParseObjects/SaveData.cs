using UnityEngine;

[System.Serializable]
public class StageSaved 
{
    public string SceneName;
    public string PositionX;
    public string PositionY;
    public string PositionZ;
    public string CameraX;
    public string CameraY;
    public string CameraZ;
}

[System.Serializable]
public class Interaction 
{
    public string InteractionName;
}

[System.Serializable]
public class InteractionCollection 
{
    public Interaction[] Interaction;
}

[System.Serializable]
public class SaveData
{
    public StageSaved StageSaved;
    public EvidenceCollection EvidenceSaved;
    public InteractionCollection InteractionsDone;
    public PlotPointCollection plotPointsPassed;
}
