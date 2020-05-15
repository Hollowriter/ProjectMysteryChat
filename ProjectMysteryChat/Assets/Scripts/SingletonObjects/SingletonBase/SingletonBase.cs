using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    bool activated = false;
    public static T _instance;

    public static T instance
    {
        get
        {
            if (_instance == null) _instance = (T)FindObjectOfType(typeof(T));
            return _instance;
        }
    }

    protected virtual void SingletonAwake()
    {
        if (_instance == null)
        {
            // DontDestroyOnLoad(gameObject);
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void BehaveSingleton()
    {
    }

    protected virtual bool ConditionsToBeActive()
    {
        return activated;
    }

    public void SetActivated(bool _activated)
    {
        activated = _activated;
    }

    public bool GetActivated()
    {
        return activated;
    }
}
