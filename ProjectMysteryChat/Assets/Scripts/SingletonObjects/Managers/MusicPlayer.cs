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

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        currentMusicState = MusicState.NONE;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Awake() 
    {
        SingletonAwake();
    }

    private void PlayMusic() 
    { 
    }

    public void SetMusicState(MusicState newMusicState) 
    {
        currentMusicState = newMusicState;
        PlayMusic();
    }
}
