using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceText : MonoBehaviour
{
    public static EvidenceText evidenceText = null;
    public bool activated;
    [SerializeField]
    Text itemText;
    [SerializeField]
    Text descriptionText;

    private void Awake()
    {
        /*itemText = this.GetComponent<Text>();
        descriptionText = this.GetComponentInChildren<Text>();*/
        activated = false;
        if (evidenceText == null)
        {
            DontDestroyOnLoad(gameObject);
            evidenceText = this;
        }
        else if (evidenceText != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetActivated(bool _activated)
    {
        activated = _activated;
    }

    public bool GetActivated()
    {
        return activated;
    }

    public void ShowItem(ItemSlot itemSelected)
    {
        if (activated)
        {
            itemText.text = "Evidence: " + itemSelected.GetItemName();
            descriptionText.text = "Description: " + itemSelected.GetItemDescription();
        }
    }

    public void DeleteText()
    {
        if (activated)
        {
            itemText.text = " ";
            descriptionText.text = " ";
        }
    }
}
