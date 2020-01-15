using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Group : MonoBehaviour
{
    public int Index;//the group's Index
    public static GameObject CreateGroup(GameObject levelsGroupPrefab, Transform groupsParent, int groupIndex, int columnsPerGroup)
    {
        //Create Levels Group
        GameObject levelsGroup = Instantiate(levelsGroupPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        levelsGroup.transform.SetParent(groupsParent);
        levelsGroup.name = "Group-" + CommonUtil.IntToString(groupIndex + 1);
        levelsGroup.transform.localScale = Vector3.one;
        levelsGroup.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        levelsGroup.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        levelsGroup.GetComponent<Group>().Index = groupIndex;
        levelsGroup.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        levelsGroup.GetComponent<GridLayoutGroup>().constraintCount = columnsPerGroup;
        return levelsGroup;
    }
}
