using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCoordinate : MonoBehaviour
{
    public Vector2Int Position { 
        get { return position; }
        set { SetupPosition(value); }
    }

    private void SetupPosition(Vector2Int value)
    {
        if (!isSetuped)
            position = value;
        isSetuped = true;
    }

    private bool isSetuped = false;
    private Vector2Int position = new(0,0);
}
