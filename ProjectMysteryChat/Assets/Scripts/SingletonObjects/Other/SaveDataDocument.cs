using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataDocument : SingletonBase<SaveDataDocument>
{
    Scene scene;
    SaveData dataToSave;
    string path;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        scene = SceneManager.GetActiveScene();
        dataToSave = new SaveData();
#if UNITY_EDITOR
        path = "Assets/Resources/ItemInfo.json";
#endif
#if UNITY_STANDALONE && !UNITY_EDITOR
        path = "ProjectMysteryChat_Data/Resources/ItemInfo.json";
#endif
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void Save() 
    {
        dataToSave.StageSaved = new Stage();
        dataToSave.StageSaved.SceneName = scene.name;
        dataToSave.StageSaved.PositionX = (PlayerController.instance.gameObject.GetComponent<Transform>().position.x).ToString();
        dataToSave.StageSaved.PositionY = (PlayerController.instance.gameObject.GetComponent<Transform>().position.y).ToString();
        dataToSave.StageSaved.PositionZ = (PlayerController.instance.gameObject.GetComponent<Transform>().position.z).ToString();
        dataToSave.EvidenceSaved = new EvidenceCollection();
        dataToSave.EvidenceSaved = EvidenceInventory.instance.GetCollection();
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
                SceneManager.LoadScene(JsonUtility.FromJson<Stage>(json).SceneName);
                PlayerController.instance.GetComponent<Transform>().position = new Vector3(float.Parse(JsonUtility.FromJson<Stage>(json).PositionX), float.Parse(JsonUtility.FromJson<Stage>(json).PositionY), float.Parse(JsonUtility.FromJson<Stage>(json).PositionZ));
                // Pendiente de testear.
            }
        }
    }
}
