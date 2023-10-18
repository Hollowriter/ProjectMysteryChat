using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : SingletonBase<ResumeButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void PressingResume()
    {
        GameplayMenu.instance.DeactivateGameplayMenuOutside();
    }
}
