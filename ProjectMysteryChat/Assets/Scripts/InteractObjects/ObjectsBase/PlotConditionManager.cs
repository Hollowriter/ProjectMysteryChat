﻿using System.Collections;
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
}