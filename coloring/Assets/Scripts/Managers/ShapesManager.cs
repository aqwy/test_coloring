using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesManager : MonoBehaviour
{
    public List<Shape> shapes = new List<Shape>();
    [HideInInspector]
    public int lastSelectedShape;
    public static ShapesManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            lastSelectedShape = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class Shape
    {
        public bool showContents = true;
        public GameObject gamePrefab;
    }
}
