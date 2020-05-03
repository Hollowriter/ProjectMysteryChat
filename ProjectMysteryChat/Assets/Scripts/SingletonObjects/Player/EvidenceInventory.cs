using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceInventory : MonoBehaviour
{
    public static EvidenceInventory inventory = null;
    EvidenceCollection evidence;
    int evidenceQuantity;

    private void Awake()
    {
        evidenceQuantity = 0;
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

    public void SetCollection(EvidenceCollection _evidence)
    {
        evidence = _evidence;
        evidenceQuantity = _evidence.EvidenceList.Length;
    }

    public void AddEvidence(Evidence evidenceAdded)
    {
        evidence.EvidenceList[evidenceQuantity] = evidenceAdded;
        evidenceQuantity++;
    }

    public bool EvidenceEmpty()
    {
        if (evidence != null)
        {
            if (evidence.EvidenceList.Length > 0)
            {
                return false;
            }
        }
        return true;
    }

    public Evidence GetEvidence(int toReturn)
    {
        return evidence.EvidenceList[toReturn];
    }

    public Evidence GetEvidenceByName(string evidenceName)
    {
        if (!EvidenceEmpty())
        {
            for (int i = 0; i < evidence.EvidenceList.Length; i++)
            {
                if (evidence.EvidenceList[i].Item == evidenceName)
                {
                    return evidence.EvidenceList[i];
                }
            }
        }
        Evidence nullEvidence = new Evidence();
        nullEvidence.Item = "nullified";
        nullEvidence.Description = "No evidence found";
        return nullEvidence;
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
    public Evidence[] EvidenceList;
}
