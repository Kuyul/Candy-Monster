using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternControl : MonoBehaviour {

    //Declare Public Variables
    public GameObject[] Patterns;

    //Declare Private Variables

	public void SpawnPattern()
    {
        Instantiate(Patterns[Random.Range(0, Patterns.Length)]);
    }
}
