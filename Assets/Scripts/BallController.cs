using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    //Declare public variables
    public float VectorScaler = 1.0f;
    public float MaximumStartPos = 2.0f;
    public float MinimumDrag = .5f;
    public float MaximumDrag = 3.0f;

    //Declare private variables
    private bool IsDragging = false;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Drag and release to fling the ball in the direction of the drag
        //The size and direction of the force vector is: 
        //(current_position - release_position) * vector_scaler
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Drag Started");
            Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Debug.Log("Initial diff: " + diff.magnitude);
            if (diff.magnitude <= MaximumStartPos) {
                IsDragging = true;
                if (rb.velocity.magnitude >= 0) {
                    rb.velocity = new Vector2(0, 0);
                }
            }
        }

        //End Dragging
        if (IsDragging) {
            Vector3 releasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 result = transform.position - releasePosition;
            //The drag shouldn't be longer than the maximum drag (otherwise the ball can go at an insanlely fast speed)
            if (result.magnitude > MaximumDrag) {
                //Recalculate result
                result = result.normalized * MaximumDrag;
            }
            Debug.Log("result magnitude: " + result.magnitude);

            if (Input.GetMouseButtonUp(0))
            {
                IsDragging = false;
                //If the drag is less than minimum drag, then no force is applied on the ball
                if (result.magnitude < MinimumDrag)
                {
                    //Do Nothing for now
                }
                else
                {
                    rb.AddForce(result * VectorScaler);
                }
                Debug.Log("Drag Released: " + result);
            }
        }
    }
}
