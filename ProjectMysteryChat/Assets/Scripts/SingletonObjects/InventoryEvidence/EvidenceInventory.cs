using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EvidenceInventory : MonoBehaviour
{
    public static EvidenceInventory inventory = null;
    EvidenceCollection evidence;
    [SerializeField]
    GameObject nameSign;
    [SerializeField]
    int maxEvidenceQuantity;
    int evidenceQuantity;
    bool activated;

    private void Awake()
    {
        activated = true; // Motivo de testeo, despues setear a false
        evidenceQuantity = 0;
        evidence = new EvidenceCollection();
        evidence.Evidence = new Evidence[maxEvidenceQuantity];
        for (int i = 0; i < maxEvidenceQuantity; i++)
        {
            evidence.Evidence[i] = GetNullEvidence();
        }
        if (inventory == null)
        {
            DontDestroyOnLoad(gameObject);
            inventory = this;
        }
        else if (inventory != this)
        {
            Destroy(gameObject);
        }
    }

    void SetToCollection(EvidenceCollection _evidence)
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
        SetToCollection(evidenceAdded);
        UIItems.inventoryUI.RefreshInventory(); // Esta aca por testeo, se borrara cuando se active y desactive el inventario
    }

    public void SetActivated(bool _activated)
    {
        activated = _activated;
        UIItems.inventoryUI.enabled = _activated;
        UIItems.inventoryUI.gameObject.SetActive(_activated);
        nameSign.SetActive(_activated);
        if (_activated)
        {
            UIItems.inventoryUI.RefreshInventory();
        }
    }

    public bool GetActivated()
    {
        return activated;
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

    public Evidence GetEvidenceByName(string evidenceName)
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
    }
}

[System.Serializable]
public class Evidence
{
    public string Item;
    public string Description;
}

[System.Serializable]
public class EvidenceCollection
{
    public Evidence[] Evidence;
}
