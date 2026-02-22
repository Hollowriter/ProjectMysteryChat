using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIProfileItems : SingletonBase<UIProfileItems>
{
    ProfileSlot[] profileSlots;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        profileSlots = GetComponentsInChildren<ProfileSlot>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < profileSlots.Length; i++)
        {
            if (ProfileInventory.instance.GetProfile(i).Username != null &&
                ProfileInventory.instance.GetProfile(i).Username != "nullified")
            {
                profileSlots[i].SetIconImage(ProfileInventory.instance.GetProfile(i).Icon);
                profileSlots[i].SetItemUsername(ProfileInventory.instance.GetProfile(i).Username);
                profileSlots[i].SetItemNicknames(ProfileInventory.instance.GetProfile(i).Nicknames);
                profileSlots[i].SetItemDescription(ProfileInventory.instance.GetProfile(i).Description);
                profileSlots[i].EnableImage(true);
            }
            else
            {
                profileSlots[i].EnableImage(false);
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
