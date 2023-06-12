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
            TextBox.instance.ResetSpeechIndex();
            PortraitBoxes.instance.SetPortraitImages(JsonUtility.FromJson<PortraitCollection>(json));
            PortraitBoxes.instance.ResetPortraitIndex();
            ElectionBox.instance.SetElections(JsonUtility.FromJson<ElectionCollection>(json));
            ElectionBox.instance.SetActivated(false);
            AnswerInspector.instance.SetAnswers(JsonUtility.FromJson<AnswerCollection>(json));
            AnswerInspector.instance.SetDebateAnswers(JsonUtility.FromJson<AnswerDebateCollection>(json));
            AnswerInspector.instance.SetActivated(false);
            SingleTransitionManager.instance.SetTransition(JsonUtility.FromJson<LoneTransition>(json));
            SingleTransitionManager.instance.SetActivated(false);
            PlotPointManager.instance.CheckPlotPointCollection(JsonUtility.FromJson<PlotPointCollection>(json));
            InteractionsManager.instance.SetPermanentInteraction(JsonUtility.FromJson<InteractionCollection>(json));
            EvidenceInventory.instance.AddEvidence(_fileName);
        }
    }

    public void CheckElectionsAndInspector()
    {
        ElectionBox.instance.SetActivated(true);
        ElectionBox.instance.CallBehave();
        AnswerInspector.instance.SetActivated(true);
        SingleTransitionManager.instance.SetActivated(true);
        PlotPointManager.instance.SetActivated(true);
    }

    public string GetDocument()
    {
        return fileName;
    }
}
