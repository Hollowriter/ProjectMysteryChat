using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractObject
{
    [SerializeField]
    string levelToGo;

    public void PassLevel()
    {
        SceneManager.LoadScene(levelToGo);
    }

    public override void NearPlayer()
    {
        // Se usara cuando haya animaciones en este objeto
    }

    public override void BehaveInteraction()
    {
        PassLevel();
    }
}
