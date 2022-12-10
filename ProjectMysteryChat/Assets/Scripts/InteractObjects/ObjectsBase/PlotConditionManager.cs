using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotConditionManager : MonoBehaviour
{
    [SerializeField]
    List<PlotConditioned> objectsConditioned;

    private void Start() 
    {
        CheckConditions();
        InteractionsManager.instance.onSetPermanentInteraction += CheckConditions;
    }

    private void CheckConditions()
    {
        for (int i = 0; i < objectsConditioned.Count; i++)
        {
            objectsConditioned[i].gameObject.SetActive(true);
            objectsConditioned[i].CheckCondition();
        }
    }
}
