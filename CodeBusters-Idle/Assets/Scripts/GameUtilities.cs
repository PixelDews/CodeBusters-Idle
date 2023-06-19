using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtilities
{

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);
        return worldPos;
    }
}


