using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake
{
    public Vector2Int gridPosition;
    public int direction;

    public snake(int x, int y, int dirc) {
        gridPosition = new Vector2Int(x, y);
        direction = dirc;
    }
}
