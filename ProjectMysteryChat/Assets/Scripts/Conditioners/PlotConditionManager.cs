using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotConditionManager : MonoBehaviour
{
    [SerializeField]
    List<PlotConditioned> objectsConditioned;
    [SerializeField]
    List<PlotReactive> objectsReactive;

    private void Start() 
    {
        CheckConditions();
        CheckReactives();
        InteractionsManager.instance.onSetPermanentInteraction += CheckConditions;
        InteractionsManager.instance.onSetPermanentInteraction += CheckReactives;
    }

    private void CheckConditions()
    {
        if (objectsConditioned != null)
        {
            for (int i = 0; i < objectsConditioned.Count; i++)
            {
                if (objectsConditioned[i] != null)
                {
                    objectsConditioned[i].gameObject.SetActive(true);
                    objectsConditioned[i].CheckCondition();
                }
            }
        }
    }

    private void CheckReactives() 
    {
        if (objectsReactive != null)
        {
            for (int i = 0; i < objectsReactive.Count; i++)
            {
                if (objectsReactive[i] != null)
                {
                    objectsReactive[i].CheckReaction();
                }
            }
        }
    }
}
