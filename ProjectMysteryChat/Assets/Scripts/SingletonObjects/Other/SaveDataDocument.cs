﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class SaveDataDocument : SingletonBase<SaveDataDocument>
{
    SaveData dataToSave;
    string path;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        dataToSave = new SaveData();
#if UNITY_EDITOR
        path = "Assets/Resources/ItemInfo.json";
#endif
#if UNITY_STANDALONE && !UNITY_EDITOR
        path = "ProjectMysteryChat_Data/Resources/ItemInfo.json";
#endif
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void Save() 
    {
        dataToSave.StageSaved = new StageSaved();
        dataToSave.StageSaved.SceneName = LevelManager.instance.GetSceneName();
        dataToSave.StageSaved.PositionX = (PlayerMovement.instance.gameObject.GetComponent<Transform>().position.x).ToString();
        dataToSave.StageSaved.PositionY = (PlayerMovement.instance.gameObject.GetComponent<Transform>().position.y).ToString();
        dataToSave.StageSaved.PositionZ = (PlayerMovement.instance.gameObject.GetComponent<Transform>().position.z).ToString();
        dataToSave.StageSaved.CameraX = (CameraFollower.instance.gameObject.GetComponent<Transform>().position.x).ToString();
        dataToSave.StageSaved.CameraY = (CameraFollower.instance.gameObject.GetComponent<Transform>().position.y).ToString();
        dataToSave.StageSaved.CameraZ = (CameraFollower.instance.gameObject.GetComponent<Transform>().position.z).ToString();
        dataToSave.EvidenceSaved = new EvidenceCollection();
        dataToSave.EvidenceSaved = EvidenceInventory.instance.GetCollection();
        dataToSave.InteractionsDone = new InteractionCollection();
        dataToSave.InteractionsDone = InteractionsManager.instance.GetCollection();
        dataToSave.plotPointsPassed = new PlotPointCollection();
        dataToSave.plotPointsPassed = PlotPointManager.instance.GetPlotPointCollection();
        string json = JsonUtility.ToJson(dataToSave);
        string str = json.ToString();
        using (FileStream fs = new FileStream(path, FileMode.Create)) 
        {
            using (StreamWriter writer = new StreamWriter(fs)) 
            {
                writer.Write(str);
            }
        }
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    public void Load()
    {
        if (System.IO.File.Exists(path)) 
        {
            using (StreamReader reader = new StreamReader(path)) 
            {
                string json = reader.ReadToEnd();
                PlayerMovement.instance.GetComponent<Transform>().position = new Vector3(float.Parse(JsonUtility.FromJson<SaveData>(json).StageSaved.PositionX), float.Parse(JsonUtility.FromJson<SaveData>(json).StageSaved.PositionY), float.Parse(JsonUtility.FromJson<SaveData>(json).StageSaved.PositionZ));
                CameraFollower.instance.GetComponent<Transform>().position = new Vector3(float.Parse(JsonUtility.FromJson<SaveData>(json).StageSaved.CameraX), float.Parse(JsonUtility.FromJson<SaveData>(json).StageSaved.CameraY), float.Parse(JsonUtility.FromJson<SaveData>(json).StageSaved.CameraZ));
                EvidenceInventory.instance.SetToCollection(JsonUtility.FromJson<SaveData>(json).EvidenceSaved);
                InteractionsManager.instance.SetCollection(JsonUtility.FromJson<SaveData>(json).InteractionsDone);
                PlotPointManager.instance.CheckPlotPointCollection(JsonUtility.FromJson<SaveData>(json).plotPointsPassed);
                LevelManager.instance.ChangeScene(JsonUtility.FromJson<SaveData>(json).StageSaved.SceneName);
            }
        }
    }

    public bool IsSomethingSaved() 
    {
        if (System.IO.File.Exists(path)) 
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                if (JsonUtility.FromJson<SaveData>(json).InteractionsDone != null) {
                    if (JsonUtility.FromJson<SaveData>(json).InteractionsDone.Interaction != null)
                        return JsonUtility.FromJson<SaveData>(json).InteractionsDone.Interaction.Length > 0;
                }
            }
        }
        return false;
    }
}
