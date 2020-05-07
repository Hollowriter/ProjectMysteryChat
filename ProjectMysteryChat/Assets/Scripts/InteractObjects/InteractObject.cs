using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    string interactionFileName;

    public void SetTextToBox()
    {
        TextBox.textBox.SetDialog(interactionFileName);
    }

    public void ShowText()
    {
        TextBox.textBox.SetActivated(true);
    }

    public void SetEvidenceToInventory()
    {
        EvidenceInventory.inventory.AddEvidence(interactionFileName);
    }

    public virtual void NearPlayer()
    {
    }

    public virtual void BehaveInteraction()
    {
    }
}
