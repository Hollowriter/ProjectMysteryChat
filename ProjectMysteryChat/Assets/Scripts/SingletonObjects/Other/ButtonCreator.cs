using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCreator : SingletonBase<ButtonCreator>
{
    [SerializeField]
    GameObject buttonToCreate;
    [SerializeField]
    int sizeButtonX;
    [SerializeField]
    int sizeButtonY;

    public void CreateButton(string text){
        // Create the button. (Hollow)
    }
}
