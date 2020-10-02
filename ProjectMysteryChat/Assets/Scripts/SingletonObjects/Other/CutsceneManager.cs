using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : SingletonBase<CutsceneManager> // Cutscene manager deberia agarrar una lista de algoritmos?
{
    List<SceneAlgorithm> cutscenes; // Nota: Hacer que se puedan leer varias listas a la vez a voluntad.
    List<SceneAlgorithm> readingCutscenes; // Nota: Hacer que se lean solo las escenas de la lista.

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        cutscenes = null;
        readingCutscenes = new List<SceneAlgorithm>();
        SetActivated(false);
        DontDestroyOnLoad(gameObject);
    }

    protected override bool ConditionsToBeActive()
    {
        if (cutscenes != null /*&& cutscene.GetAlgorithmEnd() == false*/) 
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

    public void SetCutscenes(List<SceneAlgorithm> _cutscenes) 
    {
        cutscenes = _cutscenes;
    }

    public void ProcessCutscenes() // Esto es el encargado de rellenar las escenas a leer. (EN PROCESO)
    {
        if (readingCutscenes.Count == 0) 
        {
            for (int i = 0; i < cutscenes.Count; i++) 
            {
                readingCutscenes.Add(cutscenes[i]);
                if (cutscenes[i].GetWithOtherAlgorithm() == false) 
                {
                    return;
                }
            }
        }
    }

    public List<SceneAlgorithm> GetCutscenes() 
    {
        return cutscenes;
    }

    public void ActScript() 
    {
        if (ConditionsToBeActive()) 
        {
            
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
