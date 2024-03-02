using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : SingletonBase<MusicPlayer>
{
    const string path = "Audio/Music/";
    string _currentMusic;
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
        if (currentMusic != null && currentMusic != "" && currentMusic != "None")
            musicSource.clip = Resources.Load<AudioClip>(path + currentMusic);
        if (currentMusic == "None")
        {
            musicSource.Stop();
        }
        else if (currentMusic != _currentMusic && currentMusic != "" && currentMusic != null)
        {
            musicSource.Play();
        }
        _currentMusic = currentMusic;
    }

    public void SetMusicStateFromDialog(LoneTrack music) 
    {
        if (music != null) 
        {
            if (music.Music != null)
            {
                if (music.Music[0] != null)
                {
                    if (music.Music[0].MusicName != null)
                    {
                        PlayMusic(music.Music[0].MusicName);
                    }
                }
            }
        }
    }
}
