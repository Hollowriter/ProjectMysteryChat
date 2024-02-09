using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : SingletonBase<MusicPlayer>
{
    const string path = "Audio/Music/";
    [SerializeField] private AudioSource musicSource;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Awake() 
    {
        SingletonAwake();
    }

    public void PlayMusic(string currentMusic)
    {
        if (currentMusic != null && currentMusic != "")
            musicSource.clip = Resources.Load<AudioClip>(path + currentMusic);
        if (currentMusic == "None")
        {
            musicSource.Stop();
        }
        else
        {
            musicSource.Play();
        }
    }

    public void SetMusicStateFromDialog(LoneTrack music) 
    {
        if (music != null) 
        {
            if (music.Music[0].MusicName != null) 
            {
                PlayMusic(music.Music[0].MusicName);
            }
        }
    }
}
