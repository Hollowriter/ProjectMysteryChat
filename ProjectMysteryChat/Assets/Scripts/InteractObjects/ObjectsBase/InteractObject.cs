using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    string interactionFileName;

    protected virtual void Begin() 
    {
    }

    public void IShouldExist()
    {
        this.gameObject.SetActive(IShouldBeActive());
    }

    public bool IShouldBeActive()
    {
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

    public string GetInteractionFile() // This is for test purposes. (Hollow)
    {
        return interactionFileName;
    }

    public virtual void NearPlayer()
    {
    }

    public virtual void BehaveInteraction()
    {
        SpaceInstruction.instance.deactivateElements?.Invoke();
    }
}
