using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShapeTables : MonoBehaviour
{
    public Transform groupsParent;
    public GameObject shapePrefab;
    public GameObject shapesGroupPrefab;
    public static List<TableShape> shapes;
    [Range(0f, 10)]
    public float contentScaleRatio = 0.5f;
    [Range(1, 100)]
    public int shapesPerGroup = 12;
    [Range(1, 10)]
    public int columnsPerGroup = 3;

    private Transform lastShape;
    void Start()
    {
        shapes = new List<TableShape>();
        CreateShapes();
    }

    private void CreateShapes()
    {
        if (ShapesManager.instance == null)
        {
            return;
        }
        //Clear current shapes list
        shapes.Clear();

        //The ID of the shape
        int ID = 0;

        GameObject shapesGroup = null;

        float contentScale = (Screen.width * 1.0f / Screen.height) * contentScaleRatio;//content scale

        //Create Shapes inside groups
        for (int i = 0; i < ShapesManager.instance.shapes.Count; i++)
        {

            if (i % shapesPerGroup == 0)
            {
                int groupIndex = (i / shapesPerGroup);
                shapesGroup = Group.CreateGroup(shapesGroupPrefab, groupsParent, groupIndex, columnsPerGroup);              
            }

            ID = (i + 1);//the ID of the shape
                         //Create a Shape
            GameObject tableShapeGameObject = Instantiate(shapePrefab, Vector3.zero, Quaternion.identity) as GameObject;
            tableShapeGameObject.transform.SetParent(shapesGroup.transform);//setting up the shape's parent
            TableShape tableShapeComponent = tableShapeGameObject.GetComponent<TableShape>();//get TableShape Component
            tableShapeComponent.ID = ID;//setting up shape ID
            tableShapeGameObject.name = "Shape-" + ID;//shape name
            tableShapeGameObject.transform.localScale = Vector3.one;
            tableShapeGameObject.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            tableShapeGameObject.GetComponent<RectTransform>().offsetMin = Vector2.zero;

            GameObject content = Instantiate(ShapesManager.instance.shapes[i].gamePrefab, Vector3.zero, Quaternion.identity) as GameObject;

            //release unwanted resources
            Destroy(content.GetComponent<EventTrigger>());
            Destroy(content.GetComponent<UIEvents>());
            if (content.transform.Find("Parts") != null)
                Destroy(content.transform.Find("Parts").gameObject);

            content.transform.SetParent(tableShapeGameObject.transform.Find("Content"));

            RectTransform rectTransform = tableShapeGameObject.transform.Find("Content").GetComponent<RectTransform>();

            //set up the scale
            content.transform.localScale = new Vector3(contentScale, contentScale);
            //set up the anchor
            content.GetComponent<RectTransform>().anchorMin = Vector2.zero;
            content.GetComponent<RectTransform>().anchorMax = Vector2.one;
            //set up the offset
            content.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            content.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            //enable image component
            content.GetComponent<Image>().enabled = true;
            //add click listener
            tableShapeGameObject.GetComponent<Button>().onClick.AddListener(() => GameObject.FindObjectOfType<UIEvents>().AlbumShapeEvent(tableShapeGameObject.GetComponent<TableShape>()));
            content.gameObject.SetActive(true);
            shapes.Add(tableShapeComponent);//add table shape component to the list
        }

        if (ShapesManager.instance.shapes.Count == 0)
        {
            Debug.Log("There are no Shapes found");
        }
        else
        {
            Debug.Log("New shapes have been created");
        }
    }
}
