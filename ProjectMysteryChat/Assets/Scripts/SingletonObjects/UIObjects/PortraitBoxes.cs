using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitBoxes : SingletonBase<PortraitBoxes>
{
    [SerializeField]
    RawImage portraitLeft;
    [SerializeField]
    RawImage portraitRight;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        portraitLeft.gameObject.SetActive(false);
        portraitRight.gameObject.SetActive(false);
    }

    void Awake()
    {
        SingletonAwake();
    }
}
