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

    private void CheckinteractionsToActivate() 
    {
        interactionsToActivate = 0;
        for (int i = 0; i < interactionNamesToActivate.Count; i++) 
        {
            for (int r = 0; r < InteractionsManager._instance.GetCollection().Interaction.Length; r++) 
            {
                if (interactionNamesToActivate[i] == InteractionsManager._instance.GetCollection().Interaction[r].InteractionName) 
                {
                    interactionsToActivate++;
                    break;
                }
            }
        }
    }

    private void CheckinteractionsToDeactivate()
    {
        interactionsToDeactivate = 0;
        for (int i = 0; i < interactionNamesToDeactivate.Count; i++) 
        {
            for (int r = 0; r < InteractionsManager._instance.GetCollection().Interaction.Length; r++) 
            {
                if (interactionNamesToDeactivate[i] == InteractionsManager._instance.GetCollection().Interaction[r].InteractionName) 
                {
                    interactionsToDeactivate++;
                    break;
                }
            }
        }
    }

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
        CheckinteractionsToActivate();
        CheckinteractionsToDeactivate();
        this.gameObject.SetActive(ConfirmActivation());
    }
}
