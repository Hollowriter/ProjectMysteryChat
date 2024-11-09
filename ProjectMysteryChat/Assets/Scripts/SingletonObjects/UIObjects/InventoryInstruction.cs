using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryInstruction : SingletonBase<InventoryInstruction>
{
    [SerializeField] private List<GameObject> elements;
    [SerializeField] private GameObject notedElement;
    public Action activateNotedElement;
    public Action deactivateNotedElement;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        SceneManager.activeSceneChanged -= ActivateDeactivateAll;
        SceneManager.activeSceneChanged += ActivateDeactivateAll;
        activateNotedElement -= ActivateNotedElement;
        activateNotedElement += ActivateNotedElement;
        deactivateNotedElement -= DeactivateNotedElement;
        deactivateNotedElement += DeactivateNotedElement;
    }

    private void Awake() 
    {
        SingletonAwake();
    }

    private void ActivateDeactivateAll(Scene previousScene, Scene nextScene)
    {
        if (nextScene.name != "Menu" && nextScene.name != "Prologue")
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].SetActive(false);
            }
        }
        notedElement.SetActive(false);
    }

    private void ActivateNotedElement() 
    {
        notedElement.SetActive(true);
    }

    private void DeactivateNotedElement() 
    {
        notedElement.SetActive(false);
    }
}
