using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpace : SingletonBase<PressSpace>
{
    [SerializeField] private List<GameObject> elements;
    public Action activateElements;
    public Action deactivateElements;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        activateElements += ActivateElements;
        deactivateElements += DeactivateElements;
    }

    private void Awake() 
    {
        SingletonAwake();
    }

    private void ActivateElements() 
    {
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].SetActive(true);
        }
    }

    private void DeactivateElements() 
    {
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].SetActive(false);
        }
    }
}
