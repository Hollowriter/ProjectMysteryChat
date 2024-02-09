using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicState
{
    NONE,
    MAINTHEME,
    INTRO,
    INVESTIGATION,
    QUESTIONING,
    CONFRONTATION,
    MSMAKI95,
    CHRONOWRITER1885,
    EXPLANATION,
    TENSION
}

public class MusicPlayer : SingletonBase<MusicPlayer>
{
    private MusicState currentMusicState;
    const string path = "Audio/Music/";
    [SerializeField] private AudioSource musicSource;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        currentMusicState = MusicState.NONE;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Awake() 
    {
        SingletonAwake();
        PlayMusic();
    }

    private void PlayMusic()
    {
        switch (currentMusicState) 
        {
            case MusicState.INTRO:
                musicSource.clip = Resources.Load<AudioClip>(path + "Cuadro de dialogo");
                break;
            case MusicState.INVESTIGATION:
                musicSource.clip = Resources.Load<AudioClip>(path + "Investigacion");
                break;
            case MusicState.TENSION:
                musicSource.clip = Resources.Load<AudioClip>(path + "Tension");
                break;
            case MusicState.MAINTHEME:
                musicSource.clip = Resources.Load<AudioClip>(path + "Inicio");
                break;
            case MusicState.QUESTIONING:
                musicSource.clip = Resources.Load<AudioClip>(path + "Interrogatorio");
                break;
            case MusicState.EXPLANATION:
                musicSource.clip = Resources.Load<AudioClip>(path + "Explicacion");
                break;
            case MusicState.MSMAKI95:
                musicSource.clip = Resources.Load<AudioClip>(path + "MsMaki95");
                break;
            case MusicState.CHRONOWRITER1885:
                musicSource.clip = Resources.Load<AudioClip>(path + "ChronoWriter1885");
                break;
        }
        if (currentMusicState == MusicState.NONE)
        {
            musicSource.Stop();
        }
        else
        {
            musicSource.Play();
        }
    }

    public void SetMusicState(MusicState newMusicState) 
    {
        currentMusicState = newMusicState;
        PlayMusic();
    }
}
