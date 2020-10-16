using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonBase<LevelManager>
{
    private void Awake()
    {
        SingletonAwake();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }

    public string GetSceneName() 
    {
        return SceneManager.GetActiveScene().name;
    }
}
