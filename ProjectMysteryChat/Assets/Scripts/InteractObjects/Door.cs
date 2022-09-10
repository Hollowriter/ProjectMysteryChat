using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractObject
{
    [SerializeField]
    string levelToGo;
    [SerializeField]
    float newPlayerPositionX;
    [SerializeField]
    float newPlayerPositionY;

    private void Awake()
    {
        Begin();
    }

    public void PassLevel()
    {
        PlayerController.instance.ChangePlayerPosition(newPlayerPositionX, newPlayerPositionY);
        SceneManager.LoadScene(levelToGo);
    }

    public override void NearPlayer()
    {
        // Se usara cuando haya animaciones en este objeto
    }

    public override void BehaveInteraction()
    {
        if (IShouldBeActive())
        {
            PassLevel();
        }
    }
}
