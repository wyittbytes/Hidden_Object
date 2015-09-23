using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Script for game controller in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class GameController : MonoBehaviour {

	public static bool hasKey = false;		// does the player have key for drawer?
	public static bool canLeave = false;	// are the end conditions met?

	public string[] puzzles;						// list of puzzle for reference		
	public static bool[] puzzleDone = new bool[3];	// 0-Bulletin Board, 1-Desktop, 2-Drawer
	public static bool[] prizePlayed = new bool[3];	// 0-key, 1-scissors, 2-hammer

	public static bool killPhone = false;		// is the phone destroyed?
	public static bool killComputer = false;	// is the computer destroyed?

	public GameObject deskEmitter;		// particle system for desktop puzzle
	public GameObject boardEmitter;		// particle system for board puzzle

	public Text msgText;	// message text holder

	void Start()
	{
		BlankText ();	// initiate text as blank
	}

	void Update () 
	{
		// if both devices are destroyed
		if(killPhone && killComputer)
		{	
			canLeave = true; // end conditions are met
		}

		if(puzzleDone[0])	// if board puzzle is done
		{
			hasKey = true;	// player has key and turn off emitter indicator
			boardEmitter.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if(puzzleDone[1])	// if desktop puzzle is done
		{
			// turn off emitter indicator
			deskEmitter.GetComponent<ParticleSystem>().enableEmission = false;
		}
		// emitter for drawer is turned off on OpenDrawer script

		// if the puzzle is done and it hasn't displayed the prize text
		// it will do so on the main scene then blank the text
		if(puzzleDone[0] && !prizePlayed[0] && Application.loadedLevel == 0)
		{
			msgText.text = "You have received a KEY.";
			Invoke("BlankText",2f);
			prizePlayed[0] = true;
		}
		if(puzzleDone[1] && !prizePlayed[1]&& Application.loadedLevel == 0)
		{
			msgText.text = "You have received SCISSORS.";
			Invoke("BlankText",2f);
			prizePlayed[1] = true;
		}
		if(puzzleDone[2] && !prizePlayed[2]&& Application.loadedLevel == 0)
		{
			msgText.text = "You have received a HAMMER.";
			Invoke("BlankText",2f);
			prizePlayed[2] = true;
		}

		// esc button to quit the game at any time
		if(Input.GetKey (KeyCode.Escape))
		{
			Application.Quit();
		}

	}
	// function to return if the player has the key
	public bool ShowKey()
	{
		return hasKey;
	}
	// function to return if the player has met end conditions
	public bool CanLeave()
	{
		return canLeave;
	}
	// function to return if puzzle is done
	public bool IsPuzzleDone(int puzzleID)
	{
		return puzzleDone[puzzleID];
	}
	// function to set a puzzle as done
	public void SetPuzzleDone(int puzzleID)
	{
		puzzleDone [puzzleID] = true;
	}
	// function to set device as disabled
	public void DisableDevice(int device)
	{
		if(device ==1)	// disable phone
		{
			killPhone = true;
			msgText.text = ("The phone has been disabled.");
		}
		if(device ==2)	// disable computer
		{
			killComputer = true;
			msgText.text = ("The computer has been destroyed.");
		}
		Invoke("BlankText",3f);
	}
	// function for Back button
	public void BackToMain()
	{
		Application.LoadLevel (0);
	}
	// function to blank text
	void BlankText()
	{
		msgText.text = "";
	}
	// function to control Out button
	public void ClickOut()
	{
		if (canLeave) {					// if end conditions met
			Application.LoadLevel (4);	// go to ending
		} else {						// otherwise display text
			msgText.text = ("No, there's still work that can be done");
			Invoke("BlankText",2f);
		}
	}
}
