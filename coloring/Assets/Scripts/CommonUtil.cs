using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonUtil : MonoBehaviour
{
    public static string IntToString(int value)
    {
        if (value < 10)
        {
            return "0" + value;
        }
        return value.ToString();
    }
}
