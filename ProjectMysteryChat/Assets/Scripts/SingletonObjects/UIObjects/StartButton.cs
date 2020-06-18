using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : SingletonBase<StartButton>
{
    [SerializeField]
    string startScene;

    private void Awake()
    {
        SingletonAwake();
    }

    public void PressingStart() 
    {
        SceneManager.LoadScene(startScene);
    }
}
