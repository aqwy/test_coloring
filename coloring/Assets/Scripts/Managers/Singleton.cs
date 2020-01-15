using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public GameObject[] values;
    void Awake()
    {
        InitManagers();
    }

    private void InitManagers()
    {
        if (values == null)
        {
            return;
        }

        foreach (GameObject value in values)
        {
            if (GameObject.Find(value.name) == null)
            {
                GameObject temp = Instantiate(value, Vector3.zero, Quaternion.identity) as GameObject;
                temp.name = value.name;
            }
        }
    }
}

