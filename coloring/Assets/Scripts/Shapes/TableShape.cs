using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TableShape : MonoBehaviour
{
    public static TableShape selectedShape;
    public int ID = -1;

    void Start()
    {
        if (ID == -1)
        {
            string[] tokens = gameObject.name.Split('-');
            if (tokens != null)
            {
                ID = int.Parse(tokens[1]);
            }
        }
    }

    public enum StarsNumber
    {
        ZERO,
        ONE,
        TWO,
        THREE
    }
}
