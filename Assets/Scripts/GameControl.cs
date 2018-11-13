using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    //Static Gamecontrol Instance
    public static GameControl Instance;

	// Use this for initialization
	void Start () {
		if (Instance == null)
        {
            Instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextPattern()
    {

    }

    public void GameOver()
    {

    }
}
