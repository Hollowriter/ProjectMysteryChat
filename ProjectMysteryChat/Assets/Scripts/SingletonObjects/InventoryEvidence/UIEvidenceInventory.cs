using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvidenceInventory : MonoBehaviour
{
    public static UIEvidenceInventory inventoryUI = null;
    bool activated;

    private void Awake()
    {
        activated = false;
        if (inventoryUI == null)
        {
            DontDestroyOnLoad(gameObject);
            inventoryUI = this;
        }
        else if (inventoryUI != this)
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

    void RefreshInventory()
    {
    }

    void Behave()
    {
        if (activated)
        {
            RefreshInventory();
        }
    }

    private void OnGUI()
    {
        Behave();
    }
}
