using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataDocument : SingletonBase<SaveDataDocument>
{
    Scene scene;
    SaveData dataToSave;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        scene = SceneManager.GetActiveScene();
        dataToSave = new SaveData();
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
        dataToSave.EvidenceSaved = new EvidenceCollection();
        dataToSave.EvidenceSaved = EvidenceInventory.instance.GetCollection();
        string json = JsonUtility.ToJson(dataToSave);
        string path = "Assets/Resources/ItemInfo.json"; // Esto es cuando esta en el editor
        string str = json.ToString();
        using (FileStream fs = new FileStream(path, FileMode.Create)) 
        {
            using (StreamWriter writer = new StreamWriter(fs)) 
            {
                writer.Write(str);
            }
        }
        UnityEditor.AssetDatabase.Refresh(); // Esto solo cuando esta en el editor
    }
}
