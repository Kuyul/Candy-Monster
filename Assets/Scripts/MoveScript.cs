using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to any object to make them move! ahhhh :D
public class MoveScript : MonoBehaviour {

    //Declare public variables
    public Transform[] target;
    public float speed;

    //Declare private variables
    private float step;
    private int Pathindex;

    private void Start()
    {
         Pathindex = 0;
    }

    void Update () {
        step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target[Pathindex].position, step);

        if (transform.position == target[Pathindex].position)
        {
            Pathindex++;
            //Loop
            if (Pathindex >= target.Length) {
                Pathindex = 0;
            }
        }
    }
}
