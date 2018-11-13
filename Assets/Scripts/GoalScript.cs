using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Candy")
        {
            GameControl.Instance.MoveToNextPattern();
        }
    }
}
