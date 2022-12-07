using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    string interactionFileName;
    [SerializeField]
    PlotConditioned plotCondition; // Should stop deactivating itself (Hollow)

    protected virtual void Begin() 
    {
    }

    protected void IShouldExist()
    {
        this.gameObject.SetActive(IShouldBeActive());
    }

    public bool IShouldBeActive() // The condition deactivates the object. (Hollow)
    {
        if (plotCondition != null)
        {
            if (!plotCondition.CheckCondition())
            {
                return false;
            }
        }
        return true;
    }

    public void SetTextToBox()
    {
        if (TextBox.instance.GetActivated() == false && DocumentManager.instance.GetDocument() != interactionFileName)
            DocumentManager.instance.SetDocument(interactionFileName);
    }

    public void ShowText()
    {
        TextBox.instance.SetActivated(true);
        TextBox.instance.ResetSpeechIndex();
        PortraitBoxes.instance.ResetPortraitIndex();
        PortraitBoxes.instance.PutOnImage();
    }

    public virtual void NearPlayer()
    {
    }

    public virtual void BehaveInteraction()
    {
    }
}
