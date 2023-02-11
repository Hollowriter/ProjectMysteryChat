using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionToLook
{
    Up,
    UpMoving,
    Down,
    DownMoving,
    Left,
    LeftMoving,
    Right,
    RightMoving
}

public class PointToFollow : MonoBehaviour
{
    public PositionToLook positionToChange;
    public bool dontMove;
}
