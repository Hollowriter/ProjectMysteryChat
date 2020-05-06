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
}
