using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    string interactionFileName;

    public void SetTextToBox()
    {
        /*if (TextBox.instance.GetActivated() == false && TextBox.instance.GetDialogSetted() != interactionFileName)
            TextBox.instance.SetDialog(interactionFileName);*/
        if (TextBox.instance.GetActivated() == false && DocumentManager.instance.GetDocument() != interactionFileName)
            DocumentManager.instance.SetDocument(interactionFileName);
    }

    public void ShowText()
    {
        TextBox.instance.SetActivated(true);
    }

    public void SetEvidenceToInventory()
    {
        EvidenceInventory.instance.AddEvidence(interactionFileName);
        Destroy(gameObject);
    }

    public virtual void NearPlayer()
    {
    }

    public virtual void BehaveInteraction()
    {
    }
}
