using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    string interactionFileName;

    protected void IShouldExist()  // Interacciones (testear)
    {
        if (InteractionsManager.instance.InteractionExists(interactionFileName)) 
        {
            Destroy(gameObject);
        }
    }

    public void SetTextToBox()
    {
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

    protected void SetPermanentInteraction() // Interacciones (Testear)
    {
        InteractionsManager.instance.AddInteraction(interactionFileName);
    }

    public virtual void NearPlayer()
    {
    }

    public virtual void BehaveInteraction()
    {
    }
}
