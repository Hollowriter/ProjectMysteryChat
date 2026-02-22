using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSlot : MonoBehaviour
{
    [SerializeField]
    Image icon;
    string itemUsername;
    string itemNicknames;
    string itemDescription;
    const string path = "Sprites/Portraits";

    public void SetIconImage(string _iconImageName)
    {
        if (_iconImageName != null && _iconImageName != "")
            icon.sprite = Resources.Load<Sprite>(path + _iconImageName);
    }

    public void SetItemUsername(string _itemUsername)
    {
        itemUsername = _itemUsername;
    }

    public void SetItemNicknames(string _itemNicknames) 
    {
        itemNicknames = _itemNicknames;
    }

    public void SetItemDescription(string _itemDescription)
    {
        itemDescription = _itemDescription;
    }

    public void EnableImage(bool _enabled)
    {
        icon.enabled = _enabled;
    }

    public string GetUsername()
    {
        return itemUsername;
    }

    public string GetItemNickNames() 
    { 
        return itemNicknames;
    }

    public string GetItemDescription()
    {
        return itemDescription;
    }

    public void ShowItem()
    {
        ProfileText.instance.ShowProfile(this);
        AnswerInspector.instance.SetEvidenceToCheck(this.GetUsername());
    }
}
