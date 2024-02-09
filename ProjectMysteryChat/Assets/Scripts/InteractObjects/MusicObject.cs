using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : InteractObject
{
    [SerializeField] private string musicToPlay;

    private void SetStateToMusicPlayer() 
    {
        if (this.gameObject.activeInHierarchy)
        {
            MusicPlayer.instance.PlayMusic(musicToPlay);
        }
    }

    public override void BehaveInteraction()
    {
        SetStateToMusicPlayer();
    }
}
