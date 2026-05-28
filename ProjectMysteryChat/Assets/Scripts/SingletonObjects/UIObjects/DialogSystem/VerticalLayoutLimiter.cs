using UnityEngine;

public class VerticalLayoutLimiter : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private int maxItems = 5;

    public void AddItem(GameObject newItem)
    {
        if (content.childCount >= maxItems)
        {
            Destroy(content.GetChild(0).gameObject);
        }
        newItem.transform.SetParent(content, false);
    }
}
