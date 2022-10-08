using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField]
    string interactionFileName;
    PlotConditioned plotCondition;

    protected virtual void Begin() 
    {
        plotCondition = this.gameObject.GetComponent<PlotConditioned>();
    }

    protected void IShouldExist()
    {
        this.gameObject.SetActive(IShouldBeActive());
    }

    public bool IShouldBeActive()
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
        PortraitBoxes.instance.PutOnImage();
    }

    public virtual void NearPlayer()
    {
    }

    public virtual void BehaveInteraction()
    {
    }
}
