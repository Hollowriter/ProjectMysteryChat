using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceText : SingletonBase<EvidenceText>
{
    [SerializeField]
    Text itemText;
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

    public void ShowItem(ItemSlot itemSelected)
    {
        if (GetActivated())
        {
            itemText.text = "Evidence: " + itemSelected.GetItemName();
            descriptionText.text = "Description: " + itemSelected.GetItemDescription();
        }
    }

    public void DeleteText()
    {
        if (GetActivated())
        {
            itemText.text = " ";
            descriptionText.text = " ";
        }
    }
}
