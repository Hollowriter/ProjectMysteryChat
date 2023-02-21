using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotReactive : MonoBehaviour
{
    [SerializeField]
    List<string> interactionNamesToReact;
    [SerializeField]
    InteractObject obj;
    int interactionsToReact;

    void Begin()
    {
        interactionsToReact = 0;
    }

    private void Awake()
    {
        Begin();
    }

    private void CheckinteractionsToReact()
    {
        interactionsToReact = 0;
        for (int i = 0; i < interactionNamesToReact.Count; i++)
        {
            for (int r = 0; r < InteractionsManager._instance.GetCollection().Interaction.Length; r++)
            {
                if (interactionNamesToReact[i] == InteractionsManager._instance.GetCollection().Interaction[r].InteractionName)
                {
                    interactionsToReact++;
                    break;
                }
            }
        }
    }

    private bool ConfirmReaction() 
    {
        if (interactionsToReact >= interactionNamesToReact.Count)
            return true;
        return false;
    }

    public void CheckReaction() 
    {
        CheckinteractionsToReact();
       if (ConfirmReaction())
            obj.BehaveInteraction();
    }
}
