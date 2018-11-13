using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternControl : MonoBehaviour {

    //Declare Public Variables
    public GameObject[] Patterns;

    //Declare Private Variables
    private GameObject CurrentPattern;
    private GameObject NextPattern;
    private float Offset;

    void Start()
    {
        var firstPattern = Patterns[0];
        CurrentPattern = Instantiate(firstPattern, new Vector3(0,0,0), Quaternion.identity);
        SpawnPattern();
    }

    public void MoveToNextPattern()
    {
        //Destroy Current Pattern
        Destroy(CurrentPattern); //Destroy the currentPattern gameobject
        CurrentPattern = NextPattern; //Transition into New Pattern
        SpawnPattern(); //Prepare next pattern 
    }

    //Calculate the offset between the center of the current pattern and the next and instantiate it
    private void SpawnPattern()
    {
        var newPattern = Patterns[Random.Range(0, Patterns.Length)];
        Offset += GetTopPositionOffset(CurrentPattern);
        Offset += GetBottomPositionOffset(newPattern);
        var OffsetVec = new Vector3(0, Offset, 0);
        NextPattern = Instantiate(newPattern, OffsetVec, Quaternion.identity); //set next pattern to the newly created pattern
    }

    public GameObject GetCurrentPattern()
    {
        return CurrentPattern;
    }

    //Each Pattern must have a Top and Bottom indicators to indicate the distance between the center
    //We use these metrics to calculate the positions of the future patterns.
    private float GetTopPositionOffset(GameObject obj)
    {
        Vector3 Pos = new Vector3(0, 0, 0);
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Top")
            {
                Pos = child.localPosition;
            }
        }
        return Pos.y;
    }

    private float GetBottomPositionOffset(GameObject obj)
    {
        Vector3 Pos = new Vector3(0, 0, 0);
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Bottom")
            {
                Pos = child.localPosition;
            }
        }
        return Mathf.Abs(Pos.y);
    }

}
