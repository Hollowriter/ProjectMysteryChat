using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : SingletonBase<StartButton>
{
    [SerializeField] string startScene;
    [SerializeField] float startPositionX;
    [SerializeField] float startPositionY;

    private void Awake()
    {
        SingletonAwake();
    }

    public void PressingStart() 
    {
        InteractionsManager.instance.ClearInteractions(); // Pending to make a menu for this (Hollow)
        PlayerMovement.instance.gameObject.transform.position = new Vector2(startPositionX, startPositionY);
        LevelManager.instance.ChangeScene(startScene);
    }
}
