using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Script for puzzle controller in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class PuzzleScript : MonoBehaviour {

	public GameObject[] hiddenObjects;		// list of object to find
	public Text[] objectLabels;				// text label for objects
	public int puzzleID;					// 0-Bulletin Board, 1-Desktop, 2-Drawer
	private int count;						// object counter for completion
		
	private GameController gameController;	//variable linking to game controller

	void Start () 
	{
		// finds and attaches game controller to script
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();

		// populate text labels with the names from the object list
		for(int i = 0 ; i < hiddenObjects.Length; i++)
		{
			objectLabels[i].text = hiddenObjects[i].name;
		}
		count = hiddenObjects.Length;	// set counter to number of ojects
	}
	
	// function to remove label from the list
	public void RemoveLabel(int objNum)
	{
		objectLabels[objNum].text = "";
		count--;	// count down to zero

		if (count <= 0)	// once all object are collected
		{
			// the puzzle is done
			gameController.SetPuzzleDone(puzzleID);
		}
	}


}
