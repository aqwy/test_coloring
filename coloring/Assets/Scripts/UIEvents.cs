using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public void AlbumShapeEvent(TableShape tableShape)
    {
        if (tableShape == null)
        {
            return;
        }

        TableShape.selectedShape = tableShape;
    }
}
