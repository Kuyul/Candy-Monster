using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    //Declare public variables
    public float SpeedX = 2f;
    public float SpeedY = 2f;
    public float MaxMovementX = 5f;
    public float MaxMovementY = 5f;

    //Declare private variables
    private Vector3 InitPosition;

    private void Start()
    {
        InitPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        var newXPos = InitPosition.x + (Mathf.PingPong(Time.time * SpeedX, 2 * MaxMovementX) -  MaxMovementX);
        var newYPos = InitPosition.y + (Mathf.PingPong(Time.time * SpeedY, 2 * MaxMovementY) - MaxMovementY);
        transform.position = new Vector3( newXPos, newYPos, transform.position.z);
    }
}
