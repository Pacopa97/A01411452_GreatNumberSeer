using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seer : MonoBehaviour {

    private int min;
    private int max;
    private int guess;
    private LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();

    public int attempts;
    public Text guessLebel;

	// Use this for initialization
	void Start () {
        StartGame();
        ShowGuess();
	}

    private void ShowGuess()
    {
        if (attempts >= 0)
        {
            guessLebel.text = "It's your number " + guess + "?";
        }
        else
        {

            levelManager.LoadLevel("Win");

        }
       
    }

    // Update is called once per frame
    void Update () {
		
	}

    void StartGame()
    {
        min = 1;
        max = 1001;
        NextGuess();
    }

    void NextGuess()
    {
        guess = UnityEngine.Random.Range(min, max);
        attempts--;
    }

   

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
        ShowGuess();
        
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
        ShowGuess();
    }

    public void CorrectGuess()
    {

        levelManager.LoadLevel("Loss");

    }
}
