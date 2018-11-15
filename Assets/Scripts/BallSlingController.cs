using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallSlingController : MonoBehaviour
{
    //Declare public variables
    public GameObject FakeBall;
    public GameObject Sling;
    public float MaximumDrag;

    //Declare Private variables
    private bool isPressed;
    private float releaseDelay;
    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private SpriteRenderer sr;
    private CircleCollider2D cc;
    private Vector2 InitialPosition;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();

        releaseDelay = 1 / (sj.frequency * 4);
	}
	
	// Update is called once per frame
	void Update () {
        if (isPressed) {
            DragBall();
        }
	}

    private void DragBall()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 result = InitialPosition - mousePosition;

        if (result.magnitude > MaximumDrag)
        {
            //Recalculate result
            result = result.normalized * MaximumDrag;
        }

        rb.position = InitialPosition - result;
    }

    //Mouse Down and Mouse Up are called from the BallTouch class using IPointer interface
    public void MouseDown()
    {
        isPressed = true;
        sj.enabled = true;
        rb.isKinematic = true;
        AdjustSling(transform.position);
        SwingAnimDisabled(true);
        InitialPosition = transform.position;
    }
    
    public void MouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    //Release Delay is 1/4 the frequency (which is the time it takes for the ball to reach the midpoint)
    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
        SwingAnimDisabled(false);
    }

    private void SwingAnimDisabled(bool b)
    {
        sr.enabled = !b; //Need to disable so that it doesn't look like its being pulled back
        cc.enabled = !b; //Need to disable to prevent collision with objects while being pulled back
        FakeBall.SetActive(b);
    }

    //Adjust sling and fake ball location to current ball location
    private void AdjustSling(Vector3 pos)
    {
        FakeBall.GetComponent<Transform>().position = pos;
        Sling.GetComponent<Transform>().position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dash")
        {
            rb.velocity = new Vector3(0,0,0);
        }

        if (collision.tag == "Break") {
            GameControl.Instance.GameOver();
        }
    }
}
