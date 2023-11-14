using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicObject : InteractObject
{
    [SerializeField] private MusicState musicToPlay;

    private void SetStateToMusicPlayer() 
    {
        if (this.gameObject.activeInHierarchy)
        {
            MusicPlayer.instance.SetMusicState(musicToPlay);
        }
    }

    public override void BehaveInteraction()
    {
        SetStateToMusicPlayer();
    }
}
