using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : SingletonBase<CutsceneManager>
{
    List<SceneAlgorithm> cutscenes;
    List<SceneAlgorithm> readingCutscenes;
    int cutscenesFinished;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        cutscenes = null;
        readingCutscenes = new List<SceneAlgorithm>();
        cutscenesFinished = 0;
        SetActivated(false);
        DontDestroyOnLoad(gameObject);
    }

    protected override bool ConditionsToBeActive()
    {
        if (cutscenes != null) 
        {
            if (cutscenes.Count > 0)
            {
                SetActivated(true);
                return GetActivated();
            }
        }
        SetActivated(false);
        return GetActivated();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetCutscenes(List<SceneAlgorithm> _cutscenes) 
    {
        cutscenes = _cutscenes;
    }

    public List<SceneAlgorithm> GetCutscenes()
    {
        return cutscenes;
    }

    void ProcessCutscenes()
    {
        if (readingCutscenes.Count == 0) 
        {
            for (int i = 0; i < cutscenes.Count; i++) 
            {
                if (!cutscenes[i].GetAlgorithmEnd())
                {
                    readingCutscenes.Add(cutscenes[i]);
                    if (!cutscenes[i].GetWithOtherAlgorithm())
                    {
                        return;
                    }
                }
            }
        }
    }

    void ReadActScript()
    {
        if (readingCutscenes.Count > 0)
        {
            for (int i = 0; i < readingCutscenes.Count; i++)
            {
                readingCutscenes[i].ActScript();
            }
        }
    }

    void CheckReadingCutscenesEnding()
    {
        if (readingCutscenes.Count > 0)
        {
            for (int i = 0; i < readingCutscenes.Count; i++)
            {
                if (readingCutscenes[i].GetAlgorithmEnd())
                {
                    cutscenesFinished++;
                }
            }
        }
        if (cutscenesFinished >= readingCutscenes.Count)
        {
            readingCutscenes.Clear();
        }
        cutscenesFinished = 0;
    }

    void CheckCutscenesFinished() 
    {
        for (int i = 0; i < cutscenes.Count; i++) 
        {
            if (cutscenes[i].GetAlgorithmEnd()) 
            {
                cutscenesFinished++;
            }
        }
        if (cutscenesFinished >= cutscenes.Count) 
        {
            cutscenes.Clear();
        }
        cutscenesFinished = 0;
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            ProcessCutscenes();
            ReadActScript();
            CheckReadingCutscenesEnding();
            CheckCutscenesFinished();
        }
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
