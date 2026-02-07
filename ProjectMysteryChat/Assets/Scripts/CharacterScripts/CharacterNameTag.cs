using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterNameTag : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private string playerName;
    [SerializeField] private GameObject image;

    private void SetName()
    {
        nameText.text = playerName;
    }

    private void Start()
    {
        SetName();
    }

    private void Update()
    {
        if (LevelManager.instance.GetSceneName() != "Menu" &&
            LevelManager.instance.GetSceneName() != "Prologue" &&
            LevelManager.instance.GetSceneName() != "RecapScene")
        {
            nameText.gameObject.SetActive(true);
            image.SetActive(true);
        }
        else 
        {
            nameText.gameObject.SetActive(false);
            image.SetActive(false);
        }
    }
}
