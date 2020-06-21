using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DocumentManager : SingletonBase<DocumentManager>
{
    string fileName;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        SetActivated(true);
        DontDestroyOnLoad(gameObject);
        fileName = "";
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetDocument(string _fileName)
    {
        fileName = Application.streamingAssetsPath + "/Dialogs/" + _fileName;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string json = reader.ReadToEnd();
            TextBox.instance.SetDialog(JsonUtility.FromJson<DialogCollection>(json));
            ElectionBox.instance.SetElections(JsonUtility.FromJson<ElectionCollection>(json));
            AnswerInspector.instance.SetAnswers(JsonUtility.FromJson<AnswerCollection>(json));
            SingleTransitionManager.instance.SetTransition(JsonUtility.FromJson<LoneTransition>(json));
        }
    }

    public void CheckElectionsAndInspector()
    {
        ElectionBox.instance.SetActivated(true);
        AnswerInspector.instance.SetActivated(true);
        SingleTransitionManager.instance.SetActivated(true);
    }

    public string GetDocument()
    {
        return fileName;
    }
}
