using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceInventory : MonoBehaviour
{
    public static EvidenceInventory inventory = null;
    EvidenceCollection evidence;
    // Evidence evidenceSelected; // Debate si va en jugador o en inventario
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
        evidenceQuantity = _evidence.evidenceList.Length;
    }

    public void AddEvidence(Evidence evidenceAdded)
    {
        evidence.evidenceList[evidenceQuantity] = evidenceAdded;
        evidenceQuantity++;
    }

    public bool EvidenceEmpty()
    {
        if (evidence != null)
        {
            if (evidence.evidenceList.Length > 0)
            {
                return false;
            }
        }
        return true;
    }

    public Evidence GetEvidence(int toReturn)
    {
        return evidence.evidenceList[toReturn];
    }

    public Evidence GetEvidenceByName(string evidenceName)
    {
        if (!EvidenceEmpty())
        {
            for (int i = 0; i < evidence.evidenceList.Length; i++)
            {
                if (evidence.evidenceList[i].item == evidenceName)
                {
                    return evidence.evidenceList[i];
                }
            }
        }
        Evidence nullEvidence = new Evidence();
        nullEvidence.item = "nullified";
        nullEvidence.description = "No evidence found";
        return nullEvidence;
    }
}

[System.Serializable]
public class Evidence
{
    public string item;
    public string description;
}

[System.Serializable]
public class EvidenceCollection
{
    public Evidence[] evidenceList;
}
