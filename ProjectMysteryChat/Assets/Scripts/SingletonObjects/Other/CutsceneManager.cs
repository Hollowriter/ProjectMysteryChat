using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : SingletonBase<CutsceneManager>
{
    SceneAlgorithm cutscene;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        cutscene = null;
        SetActivated(false);
        DontDestroyOnLoad(gameObject);
    }

    protected override bool ConditionsToBeActive()
    {
        if (cutscene != null) 
        {
            SetActivated(true);
            return GetActivated();
        }
        SetActivated(false);
        return GetActivated();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetCutscene(SceneAlgorithm _cutscene) 
    {
        cutscene = _cutscene;
    }

    public SceneAlgorithm GetCutscene() 
    {
        return cutscene;
    }

    public void ActScript() 
    {
        if (ConditionsToBeActive()) 
        {
            cutscene.ActScript();
        }
    }

    protected override void BehaveSingleton()
    {
        ActScript();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
