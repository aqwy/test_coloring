using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ShapePart : MonoBehaviour
{
    [HideInInspector]
    public int initialSortingOrder;
    private SpriteRenderer spriteRenderer;
    private static float colorLerpSpeed = 7;
    [HideInInspector]
    public Color targetColor = Color.white;

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        initialSortingOrder = GetComponent<SpriteRenderer>().sortingOrder;

        //Apply the previous color on part
        object previousColor = Area.shapesDrawingContents[ShapesManager.instance.lastSelectedShape].shapePartsColors[name];
        if (previousColor != null)
            spriteRenderer.color = (Color)previousColor;

        targetColor = (Color)previousColor;

        //Apply the previous sorting order on part
        object previousSortingOrder = Area.shapesDrawingContents[ShapesManager.instance.lastSelectedShape].shapePartsSortingOrder[name];
        if (previousSortingOrder != null)
            spriteRenderer.sortingOrder = (int)previousSortingOrder;
    }

    void Update()
    {
        LerpToColor();
    }


    public void LerpToColor()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        if (targetColor == spriteRenderer.color)
        {
            return;
        }
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, colorLerpSpeed * Time.smoothDeltaTime);
    }

    public void ApplyInitialSortingOrder()
    {
        GetComponent<SpriteRenderer>().sortingOrder = initialSortingOrder;
    }

    public void SetColor(Color targetColor)
    {
        this.targetColor = targetColor;
    }

    public void ApplyInitialColor()
    {
        this.targetColor = Color.white;
    }
}
