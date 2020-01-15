using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions
{
    public class testbuttons : MonoBehaviour
    {
        public HorizontalScrollSnap hss;
        public Image coloringImage;

        public void PageChange()
        {
            Debug.Log(string.Format("Scroll Snap page changed to {0}", hss.CurrentPage));
        }

        public void testclick()
        {
         
            Image testimg = hss.ChildObjects[hss.CurrentPage].GetComponentInChildren<Image>();
            if (testimg)
            {
                coloringImage.sprite = testimg.sprite;
            }
        }
    }
}
