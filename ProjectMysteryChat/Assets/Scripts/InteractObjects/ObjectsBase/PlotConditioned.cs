using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotConditioned : MonoBehaviour // This should be responsible of deactivating an object regarding plot conditions. (Hollow)
{
    [SerializeField]
    List<string> interactionNamesToActivate;
    [SerializeField]
    List<string> interactionNamesToDeactivate;
    int interactionsToActivate;
    int interactionsToDeactivate;

    void Begin() 
    {
        interactionsToActivate = 0;
        interactionsToDeactivate = 0;
    }

    private void Awake()
    {
        Begin();
    }

    // ADD THE INDIVIDUAL CHECKINGS AGAIN. (Hollow)

    private bool ConfirmActivation() 
    {
        if (interactionNamesToDeactivate.Count > 0)
        {
            if (interactionsToDeactivate == interactionNamesToDeactivate.Count)
            {
                return false;
            }
        }
        if (interactionsToActivate >= interactionNamesToActivate.Count) 
            return true;
        return false;
    }

    public void CheckCondition() 
    {
        this.gameObject.SetActive(ConfirmActivation()); // Revisar como resolver la desactivacion propia. (Hollow)
    }
}
