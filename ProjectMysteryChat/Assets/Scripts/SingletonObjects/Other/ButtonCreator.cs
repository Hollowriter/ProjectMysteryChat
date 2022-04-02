using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : SingletonBase<ButtonCreator>
{
    [SerializeField]
    GameObject buttonToCreate;
    [SerializeField]
    int sizeButtonX;
    [SerializeField]
    int sizeButtonY;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(this);
    }

    void Awake(){
        SingletonAwake();
    }

    public GameObject CreateButton(string text, float posX, float posY){
        GameObject newObject = Instantiate(buttonToCreate, new Vector3(posX, posY, 0), Quaternion.identity);
        newObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeButtonX, sizeButtonY);
        newObject.GetComponentInChildren<Text>().text = text;
        newObject.gameObject.transform.SetParent(GameObject.Find("MainUICanvas").transform);
        return newObject;
    }
}
