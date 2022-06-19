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
    const string path = "Sprites/Portraits/";
    PortraitCollection portraits;
    int portraitIndex;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        portraitLeft.gameObject.SetActive(false);
        portraitRight.gameObject.SetActive(false);
        portraitIndex = 0;
    }

    void Awake()
    {
        SingletonAwake();
    }

    public void SetPortraitImages(PortraitCollection _portraits)
    {
        portraits = _portraits;
        portraitIndex = 0;
    }

    public void PutOnImage()
    {
        if (portraits != null)
        {
            if (portraitIndex < portraits.Portraits.Length)
            {
                if (portraits.Portraits[portraitIndex].CharacterLeft != "" && portraits.Portraits[portraitIndex].CharacterLeft != null 
                    && portraits.Portraits[portraitIndex].ExpressionLeft != "" && portraits.Portraits[portraitIndex].ExpressionLeft != null)
                {
                    portraitLeft.gameObject.SetActive(true);
                    portraitLeft.texture = Resources.Load<Texture>(path + portraits.Portraits[portraitIndex].CharacterLeft + "/" + portraits.Portraits[portraitIndex].ExpressionLeft);
                }
                else
                {
                    portraitLeft.gameObject.SetActive(false);
                }
                if (portraits.Portraits[portraitIndex].CharacterRight != "" && portraits.Portraits[portraitIndex].CharacterRight != null 
                    && portraits.Portraits[portraitIndex].ExpressionRight != "" && portraits.Portraits[portraitIndex].ExpressionRight != null)
                {
                    portraitRight.gameObject.SetActive(true);
                    portraitRight.texture = Resources.Load<Texture>(path + portraits.Portraits[portraitIndex].CharacterRight + "/" + portraits.Portraits[portraitIndex].ExpressionRight);
                }
                else
                {
                    portraitRight.gameObject.SetActive(false);
                }
                portraitIndex++;
                return;
            }
        }
        WipePortraitBoxes();
    }

    public void WipePortraitBoxes()
    {
        portraitLeft.gameObject.SetActive(false);
        portraitRight.gameObject.SetActive(false);
    }
}
