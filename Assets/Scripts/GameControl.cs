using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    //Static Gamecontrol Instance
    public static GameControl Instance;

    //Declare Public Variables
    public PatternControl Pattern;
    public StageControl Stage;

    // Use this for initialization
    void Start () {
		if (Instance == null)
        {
            Instance = this;
        }
	}

    //PatternControl Functions
    public void MoveToNextPattern()
    {
        Pattern.MoveToNextPattern();
        Stage.MoveToNextPattern();
    }

    public GameObject GetCurrentPattern() {
        return Pattern.GetCurrentPattern();
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(0);
    }
}
