using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractObject
{
    [SerializeField]
    string levelToGo;

    private void Awake()
    {
        Begin();
    }

    public void PassLevel()
    {
        SceneManager.LoadScene(levelToGo);
    }

    public override void NearPlayer()
    {
        // Se usara cuando haya animaciones en este objeto
        if (!IShouldBeActive()) 
        {
            Destroy(gameObject); // ESTO ES PARA TESTEAR.
        }
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            PassLevel();
        }
    }
}
