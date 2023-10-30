using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : SingletonBase<Instructions>
{
    [SerializeField] private List<GameObject> instructions;

    private void Awake()
    {
        SingletonAwake();
    }

    private void ObjectBehaviours() 
    {
        if (LevelManager.instance.GetSceneName() != "Menu" && LevelManager.instance.GetSceneName() != "Prologue") 
        {
            for (int i = 0; i < instructions.Count; i++) 
            {
                instructions[i].SetActive(true);
            }
        }
        else 
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                instructions[i].SetActive(false);
            }
        }
    }

    protected override void BehaveSingleton()
    {
        ObjectBehaviours();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
