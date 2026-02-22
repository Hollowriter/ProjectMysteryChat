using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileText : SingletonBase<ProfileText>
{
    [SerializeField]
    Text usernameText;
    [SerializeField]
    Text nicknamesText;
    [SerializeField]
    Text descriptionText;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void ShowProfile(ProfileSlot profileSelected)
    {
        if (GetActivated())
        {
            usernameText.text = "Username: " + profileSelected.GetUsername();
            nicknamesText.text = "Nicknames: " + profileSelected.GetItemNickNames();
            descriptionText.text = "Description: " + profileSelected.GetItemDescription();
        }
    }

    public void DeleteText()
    {
        if (GetActivated())
        {
            usernameText.text = " ";
            nicknamesText.text= " ";
            descriptionText.text = " ";
        }
    }
}
