using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProfileInventory : SingletonBase<ProfileInventory>
{
    ProfileCollection profile;
    [SerializeField]
    GameObject nameSign;
    [SerializeField]
    int maxProfileQuantity;
    int profileQuantity;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        profileQuantity = 0;
        profile = new ProfileCollection();
        profile.Profile = new Profile[maxProfileQuantity];
        for (int i = 0; i < maxProfileQuantity; i++)
        {
            profile.Profile[i] = GetNullProfile();
        }
        SetActivatedInventoryMembers(false);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetToCollection(ProfileCollection _profile)
    {
        if (!ProfileFull())
        {
            for (int i = 0; i < _profile.Profile.Length; i++)
            {
                profile.Profile[profileQuantity] = _profile.Profile[i];
                profileQuantity++;
                if (ProfileFull())
                    return;
            }
        }
    }

    public void ClearInventory()
    {
        profileQuantity = 0;
        profile = null;
        profile = new ProfileCollection();
        profile.Profile = new Profile[maxProfileQuantity];
        for (int i = 0; i < maxProfileQuantity; i++)
        {
            profile.Profile[i] = GetNullProfile();
        }
        SetActivatedInventoryMembers(false);
    }

    ProfileCollection ProcessProfileDocument(string documentName)
    {
        ProfileCollection profileProcessed;
        string fileName = Application.streamingAssetsPath + "/Dialogs/" + documentName;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string json = reader.ReadToEnd();
            profileProcessed = JsonUtility.FromJson<ProfileCollection>(json);
        }
        return profileProcessed;
    }

    public void AddProfile(string profileFileName)
    {
        ProfileCollection profileAdded = ProcessProfileDocument(profileFileName);
        if (profileAdded != null)
        {
            if (profileAdded.Profile != null)
            {
                SetToCollection(profileAdded);
            }
        }
    }

    public void SetActivatedInventoryMembers(bool _activated)
    {
        SetActivated(_activated);
        this.gameObject.SetActive(_activated);
        if (_activated)
        {
            UIProfileItems.instance.enabled = _activated;
            UIProfileItems.instance.gameObject.SetActive(_activated);
            ProfileText.instance.SetActivated(_activated);
            ProfileText.instance.DeleteText();
            PresentButton.instance.SetActivated(_activated);
            nameSign.SetActive(_activated);
            UIProfileItems.instance.RefreshInventory();
        }
    }

    public bool ProfileEmpty()
    {
        if (profile != null)
        {
            if (profile.Profile != null)
            {
                if (profile.Profile.Length > 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool ProfileFull()
    {
        if (profileQuantity >= maxProfileQuantity)
        {
            return true;
        }
        return false;
    }

    public Profile GetNullProfile()
    {
        Profile nullProfile = new Profile();
        nullProfile.Username = "nullified";
        nullProfile.Nicknames = "No nicknames found";
        nullProfile.Description = "No description found";
        return nullProfile;
    }

    public Profile GetProfile(int toReturn)
    {
        if (!ProfileEmpty())
        {
            if (toReturn < profile.Profile.Length)
            {
                return profile.Profile[toReturn];
            }
        }
        return GetNullProfile();
    }

    public ProfileCollection GetCollection()
    {
        return profile;
    }
}
