using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class DrawingContents : MonoBehaviour
{
    public Hashtable shapePartsColors = new Hashtable();
    public Hashtable shapePartsSortingOrder = new Hashtable();
    public int currentSortingOrder;
    public int lastPartSortingOrder;

    void Start()
    {
        currentSortingOrder = 0;
    }
}
