using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryChanger : MonoBehaviour
{
    public void Pressed() 
    {
        if (EvidenceInventory.instance.enabled)
            EvidenceInventory.instance.SetActivatedInventoryMembers(false);
        else
            EvidenceInventory.instance.SetActivatedInventoryMembers(true);
        if (ProfileInventory.instance.enabled)
            ProfileInventory.instance.SetActivatedInventoryMembers(false);
        else
            ProfileInventory.instance.SetActivatedInventoryMembers(true);
    }
}
