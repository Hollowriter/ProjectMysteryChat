using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField]
    Image icon;
    string itemName;
    string itemDescription;
    const string path = "Sprites/FinalSprites/FinalObjectSprites/";

    public void SetIconImage(string _iconImageName) 
    {
        if (_iconImageName != null && _iconImageName != "")
            icon.sprite = Resources.Load<Sprite>(path + _iconImageName);
    }

    public void SetItemName(string _itemName)
    {
        itemName = _itemName;
    }

    public void SetItemDescription(string _itemDescription)
    {
        itemDescription = _itemDescription;
    }

    public void EnableImage(bool _enabled)
    {
        icon.enabled = _enabled;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemDescription()
    {
        return itemDescription;
    }

    public void ShowItem()
    {
        EvidenceText.instance.ShowItem(this);
        AnswerInspector.instance.SetEvidenceToCheck(this.GetItemName());
    }
}
