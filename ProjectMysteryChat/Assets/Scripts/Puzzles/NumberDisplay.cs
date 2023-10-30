using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class NumberDisplay : MonoBehaviour
{
    [SerializeField] private TextMesh numberText;
    [SerializeField] private Number number;

    private void DisplayNumberValue() 
    {
        if (number != null && numberText != null)
            numberText.text = number.GetValue().ToString();
    }

    private void Update()
    {
        DisplayNumberValue();
    }
}
