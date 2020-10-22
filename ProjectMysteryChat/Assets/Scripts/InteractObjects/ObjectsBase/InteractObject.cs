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
        if (InteractionsManager.instance.InteractionExists(interactionFileName)) 
        {
            Destroy(gameObject);
        }
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
    }

    protected void SetPermanentInteraction()
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
