using UnityEngine;

[System.Serializable]
public class Profile
{
    public string Icon;
    public string Username;
    public string Nicknames;
    public string Description;
}

[System.Serializable]
public class ProfileCollection
{
    public Profile[] Profile;
}
