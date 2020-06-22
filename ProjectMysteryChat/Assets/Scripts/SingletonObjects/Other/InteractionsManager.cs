using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class InteractionsManager : SingletonBase<InteractionsManager>
{
    InteractionCollection Interactions;
    [SerializeField]
    int interactionsLimit;
    int interactionsQuantity;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        Interactions = new InteractionCollection();
        Interactions.Interactions = new Interaction[interactionsLimit];
        for (int i = 0; i < Interactions.Interactions.Length; i++) 
        {
            Interactions.Interactions[i] = new Interaction();
            Interactions.Interactions[i].InteractionName = "null";
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
            Interactions.Interactions[interactionsQuantity].InteractionName = interactionName;
            interactionsQuantity++;
        }
    }

    public void SetCollection(InteractionCollection newCollection) 
    {
        Interactions = newCollection;
        interactionsQuantity = 0;
        for (int i = 0; i < Interactions.Interactions.Length; i++) 
        { 
            if (Interactions.Interactions[i].InteractionName != "null") 
            {
                interactionsQuantity++;
            }
        }
    }

    public bool InteractionExists(string interactionName) 
    {
        for (int i = 0; i < Interactions.Interactions.Length; i++) 
        {
            if (Interactions.Interactions[i].InteractionName == interactionName) 
            {
                return true;
            }
        }
        return false;
    }

    public InteractionCollection GetCollection() 
    {
        return Interactions;
    }
}
