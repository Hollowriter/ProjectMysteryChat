using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EvidenceInventory : SingletonBase<EvidenceInventory>
{
    EvidenceCollection evidence;
    [SerializeField]
    GameObject nameSign;
    [SerializeField]
    int maxEvidenceQuantity;
    int evidenceQuantity;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        evidenceQuantity = 0;
        evidence = new EvidenceCollection();
        evidence.Evidence = new Evidence[maxEvidenceQuantity];
        for (int i = 0; i < maxEvidenceQuantity; i++)
        {
            evidence.Evidence[i] = GetNullEvidence();
        }
        SetActivatedInventoryMembers(false);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetToCollection(EvidenceCollection _evidence)
    {
        if (!EvidenceFull())
        {
            for (int i = 0; i < _evidence.Evidence.Length; i++)
            {
                evidence.Evidence[evidenceQuantity] = _evidence.Evidence[i];
                evidenceQuantity++;
                if (EvidenceFull())
                    return;
            }
        }
    }

    EvidenceCollection ProcessEvidenceDocument(string documentName)
    {
        EvidenceCollection evidenceProcessed;
        string fileName = Application.streamingAssetsPath + "/Dialogs/" + documentName;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string json = reader.ReadToEnd();
            evidenceProcessed = JsonUtility.FromJson<EvidenceCollection>(json);
        }
        return evidenceProcessed;
    }

    public void AddEvidence(string evidenceFileName)
    {
        EvidenceCollection evidenceAdded = ProcessEvidenceDocument(evidenceFileName);
        if (evidenceAdded != null)
        {
            if (evidenceAdded.Evidence != null)
            {
                SetToCollection(evidenceAdded);
            }
        }
    }

    public void SetActivatedInventoryMembers(bool _activated)
    {
        SetActivated(_activated);
        this.gameObject.SetActive(_activated);
        if (_activated)
        {
            UIItems.instance.enabled = _activated;
            UIItems.instance.gameObject.SetActive(_activated);
            EvidenceText.instance.SetActivated(_activated);
            EvidenceText.instance.DeleteText();
            PresentButton.instance.SetActivated(_activated);
            nameSign.SetActive(_activated);
            UIItems.instance.RefreshInventory();
        }
    }

    public bool EvidenceEmpty()
    {
        if (evidence != null)
        {
            if (evidence.Evidence != null)
            {
                if (evidence.Evidence.Length > 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool EvidenceFull()
    {
        if (evidenceQuantity >= maxEvidenceQuantity)
        {
            return true;
        }
        return false;
    }

    public Evidence GetNullEvidence()
    {
        Evidence nullEvidence = new Evidence();
        nullEvidence.Item = "nullified";
        nullEvidence.Description = "No evidence found";
        return nullEvidence;
    }

    public Evidence GetEvidence(int toReturn)
    {
        if (!EvidenceEmpty())
        {
            if (toReturn < evidence.Evidence.Length)
            {
                return evidence.Evidence[toReturn];
            }
        }
        return GetNullEvidence();
    }

    public EvidenceCollection GetCollection() 
    {
        return evidence;
    }

    /*public Evidence GetEvidenceByName(string evidenceName)
    {
        if (!EvidenceEmpty())
        {
            for (int i = 0; i < evidence.Evidence.Length; i++)
            {
                if (evidence.Evidence[i].Item == evidenceName)
                {
                    return evidence.Evidence[i];
                }
            }
        }
        return GetNullEvidence();
    }*/
}
