using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControl : MonoBehaviour {

    //Declare public variables
    public float step = 1.0f;

    //Declare Private variables
    private Vector3 NextPatternPos;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, NextPatternPos, step * Time.deltaTime);
    }

    //Update the nextpatternpos variables so that the stage moves onto the next pattern
    public void MoveToNextPattern()
    {
        var currentPattern = GameControl.Instance.GetCurrentPattern();
        NextPatternPos = currentPattern.GetComponent<Transform>().position;
    }
}
