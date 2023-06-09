using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitBoxes : SingletonBase<PortraitBoxes>
{
    [SerializeField]
    Image portraitLeft;
    [SerializeField]
    Image portraitRight;
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
    }

    public void ResetPortraitIndex()
    {
        portraitIndex = 0;
    }

    public void NextImage() 
    {
        portraitIndex++;
        if (portraitIndex >= portraits.Portraits.Length) 
        {
            portraitIndex = portraits.Portraits.Length - 1;
        }
        PutOnImage();
    }

    public void ContinuousNextImage() 
    {
        portraitIndex++;
        if (portraitIndex >= portraits.Portraits.Length)
        {
            WipePortraitBoxes();
            ResetPortraitIndex();
            return;
        }
        PutOnImage();

    }

    public void PreviousImage() 
    {
        portraitIndex--;
        if (portraitIndex < 0)
        {
            portraitIndex = 0;
        }
        PutOnImage();
    }

    public void PutOnImage() // Adapt this to be able to be used in interrogations. (Hollow)
    {
        if (portraits != null)
        {
            if (portraits.Portraits != null)
            {
                if (portraitIndex < portraits.Portraits.Length)
                {
                    if (portraits.Portraits[portraitIndex].CharacterLeft != "" && portraits.Portraits[portraitIndex].CharacterLeft != null 
                        && portraits.Portraits[portraitIndex].ExpressionLeft != "" && portraits.Portraits[portraitIndex].ExpressionLeft != null)
                    {
                        portraitLeft.gameObject.SetActive(true);
                        portraitLeft.sprite = Resources.Load<Sprite>(path + portraits.Portraits[portraitIndex].CharacterLeft + "/" + portraits.Portraits[portraitIndex].ExpressionLeft);
                    }
                    else
                    {
                        portraitLeft.gameObject.SetActive(false);
                    }
                    if (portraits.Portraits[portraitIndex].CharacterRight != "" && portraits.Portraits[portraitIndex].CharacterRight != null 
                        && portraits.Portraits[portraitIndex].ExpressionRight != "" && portraits.Portraits[portraitIndex].ExpressionRight != null)
                    {
                        portraitRight.gameObject.SetActive(true);
                        portraitRight.sprite = Resources.Load<Sprite>(path + portraits.Portraits[portraitIndex].CharacterRight + "/" + portraits.Portraits[portraitIndex].ExpressionRight);
                    }
                    else
                    {
                        portraitRight.gameObject.SetActive(false);
                    }
                    // portraitIndex++;
                    return;
                }
            }
        }
        /*WipePortraitBoxes();
        ResetPortraitIndex();*/
    }

    private void WipePortraitBoxes()
    {
        portraitLeft.gameObject.SetActive(false);
        portraitRight.gameObject.SetActive(false);
    }
}
