using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionToLook
{
    Up,
    Down,
    Left,
    Right
}

public class PointToFollow : MonoBehaviour
{
    public PositionToLook positionToChange;
}
