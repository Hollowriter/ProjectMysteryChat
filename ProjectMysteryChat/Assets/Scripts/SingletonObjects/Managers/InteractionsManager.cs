using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Events;

public class InteractionsManager : SingletonBase<InteractionsManager>
{
    private InteractionCollection Interaction;
    [SerializeField]
    private int interactionsLimit;
    private int interactionsQuantity;
    public UnityAction onSetPermanentInteraction;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        Interaction = new InteractionCollection();
        Interaction.Interaction = new Interaction[interactionsLimit];
        for (int i = 0; i < Interaction.Interaction.Length; i++) 
        {
            Interaction.Interaction[i] = new Interaction();
            Interaction.Interaction[i].InteractionName = "null";
        }
        interactionsQuantity = 0;
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void AddInteraction(string interactionName)
    {
        if (interactionsQuantity < interactionsLimit)
        {
            Interaction.Interaction[interactionsQuantity].InteractionName = interactionName;
            interactionsQuantity++;
        }
    }

    public void SetCollection(InteractionCollection newCollection) 
    {
        Interaction = newCollection;
        interactionsQuantity = 0;
        for (int i = 0; i < Interaction.Interaction.Length; i++) 
        { 
            if (Interaction.Interaction[i].InteractionName != "null") 
            {
                interactionsQuantity++;
            }
        }
    }

    public void SetPermanentInteraction(InteractionCollection collectionToCheck)
    {
        if (collectionToCheck != null)
        {
            if (collectionToCheck.Interaction != null)
            {
                for (int i = 0; i < collectionToCheck.Interaction.Length; i++)
                {
                    if (collectionToCheck.Interaction[i].InteractionName != "null")
                    {
                        AddInteraction(collectionToCheck.Interaction[i].InteractionName);
                    }
                }
            }
        }
        onSetPermanentInteraction?.Invoke();
    }

    public bool InteractionExists(string interactionName) 
    {
        for (int i = 0; i < Interaction.Interaction.Length; i++) 
        {
            if (Interaction.Interaction[i].InteractionName == interactionName) 
            {
                return true;
            }
        }
        return false;
    }

    public InteractionCollection GetCollection() 
    {
        return Interaction;
    }
}
