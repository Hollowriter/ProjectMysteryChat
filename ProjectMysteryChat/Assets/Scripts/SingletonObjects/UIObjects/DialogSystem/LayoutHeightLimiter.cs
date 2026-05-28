using UnityEngine;
using UnityEngine.UI;

public class LayoutHeightLimiter : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private float maxHeight = 500f;
    [SerializeField] private ContentSizeFitter fitter;

    void Update()
    {
        if (content.sizeDelta.y > maxHeight)
        {
            fitter.enabled = false;
            content.sizeDelta = new Vector2(content.sizeDelta.x, maxHeight);
        }
        else
        {
            fitter.enabled = true;
        }
    }
}
