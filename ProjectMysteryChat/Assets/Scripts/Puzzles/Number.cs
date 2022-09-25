using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    int _value;
    const int LIMITVALUE = 9;

    void Awake()
    {
        _value = 0;
    }

    public void SetValue(int value)
    {
        _value = value;
    }

    public int GetValue()
    {
        return _value;
    }

    public void IncreaseValue()
    {
        if (_value < LIMITVALUE)
        {
            _value++;
            return;
        }
        _value = 0;
    }

    public void DecreaseValue()
    {
        if (_value >= 0)
        {
            _value--;
            return;
        }
        _value = LIMITVALUE;
    }
}
