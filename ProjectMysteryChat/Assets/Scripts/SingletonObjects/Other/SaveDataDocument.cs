using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
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
        dataToSave.StageSaved.SceneName =
            LevelManager.instance.GetSceneName();
        Vector3 playerPos = PlayerMovement.instance.transform.position;
        Vector3 cameraPos = CameraFollower.instance.transform.position;
        dataToSave.StageSaved.PositionX =
            playerPos.x.ToString(CultureInfo.InvariantCulture);
        dataToSave.StageSaved.PositionY =
            playerPos.y.ToString(CultureInfo.InvariantCulture);
        dataToSave.StageSaved.PositionZ =
            playerPos.z.ToString(CultureInfo.InvariantCulture);
        dataToSave.StageSaved.CameraX =
            cameraPos.x.ToString(CultureInfo.InvariantCulture);
        dataToSave.StageSaved.CameraY =
            cameraPos.y.ToString(CultureInfo.InvariantCulture);
        dataToSave.StageSaved.CameraZ =
            cameraPos.z.ToString(CultureInfo.InvariantCulture);
        dataToSave.EvidenceSaved = EvidenceInventory.instance.GetCollection();
        dataToSave.InteractionsDone = InteractionsManager.instance.GetCollection();
        dataToSave.plotPointsPassed = PlotPointManager.instance.GetPlotPointCollection();
        string json = JsonUtility.ToJson(dataToSave, true);
        using (FileStream fs = new FileStream(path, FileMode.Create))
        using (StreamWriter writer = new StreamWriter(fs))
        {
            writer.Write(json);
        }
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    public void Load()
    {
        if (!File.Exists(path))
            return;

        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            PlayerMovement.instance.transform.position = new Vector3(
                float.Parse(data.StageSaved.PositionX, CultureInfo.InvariantCulture),
                float.Parse(data.StageSaved.PositionY, CultureInfo.InvariantCulture),
                float.Parse(data.StageSaved.PositionZ, CultureInfo.InvariantCulture)
            );
            CameraFollower.instance.transform.position = new Vector3(
                float.Parse(data.StageSaved.CameraX, CultureInfo.InvariantCulture),
                float.Parse(data.StageSaved.CameraY, CultureInfo.InvariantCulture),
                float.Parse(data.StageSaved.CameraZ, CultureInfo.InvariantCulture)
            );
            EvidenceInventory.instance.ClearInventory();
            EvidenceInventory.instance.SetToCollection(data.EvidenceSaved);
            InteractionsManager.instance.ClearInteractions();
            InteractionsManager.instance.SetCollection(data.InteractionsDone);
            PlotPointManager.instance.CheckPlotPointCollection(data.plotPointsPassed);
            LevelManager.instance.ChangeScene(data.StageSaved.SceneName);
        }
    }

    public bool IsSomethingSaved()
    {
        if (!File.Exists(path))
            return false;
        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (data.InteractionsDone != null &&
                data.InteractionsDone.Interaction != null)
            {
                return data.InteractionsDone.Interaction.Length > 0;
            }
        }
        return false;
    }
}