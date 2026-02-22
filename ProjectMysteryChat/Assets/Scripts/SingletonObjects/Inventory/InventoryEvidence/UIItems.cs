using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItems : SingletonBase<UIItems>
{
    ItemSlot[] itemSlots;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        itemSlots = GetComponentsInChildren<ItemSlot>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (EvidenceInventory.instance.GetEvidence(i).Item != null && 
                EvidenceInventory.instance.GetEvidence(i).Item != "nullified")
            {
                itemSlots[i].SetIconImage(EvidenceInventory.instance.GetEvidence(i).Icon);
                itemSlots[i].SetItemName(EvidenceInventory.instance.GetEvidence(i).Item);
                itemSlots[i].SetItemDescription(EvidenceInventory.instance.GetEvidence(i).Description);
                itemSlots[i].EnableImage(true);
            }
            else
            {
                itemSlots[i].EnableImage(false);
            }
        }
    }

    protected override void BehaveSingleton()
    {
        RefreshInventory();
    }

    private void Start()
    {
        BehaveSingleton();
    }
}
