using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItems : MonoBehaviour
{
    public static UIItems inventoryUI = null;
    ItemSlot[] itemSlots;

    private void Awake()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
        if (inventoryUI == null)
        {
            inventoryUI = this;
        }
        else if (inventoryUI != this)
        {
            Destroy(gameObject);
        }
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (EvidenceInventory.inventory.GetEvidence(i).Item != null && 
                EvidenceInventory.inventory.GetEvidence(i).Item != "nullified")
            {
                itemSlots[i].SetItemName(EvidenceInventory.inventory.GetEvidence(i).Item);
                itemSlots[i].SetItemDescription(EvidenceInventory.inventory.GetEvidence(i).Description);
                itemSlots[i].EnableImage(true);
            }
            else
            {
                itemSlots[i].EnableImage(false);
            }
        }
    }

    public void StartBehave()
    {
        RefreshInventory();
    }

    private void Start()
    {
        StartBehave();
    }
}
