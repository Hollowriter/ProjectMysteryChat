using UnityEngine;
using UnityEngine.UI;

public class LayoutHeightLimiter : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private float maxHeight;

    public void RefreshLayout()
    {
        Canvas.ForceUpdateCanvases();
        float height = LayoutUtility.GetPreferredHeight(content);
        float finalHeight = Mathf.Min(height, maxHeight);
        content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, finalHeight);
    }
}
