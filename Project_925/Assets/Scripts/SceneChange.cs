using UnityEngine;
using System.Collections;

//Script for camera mover in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class SceneChange : MonoBehaviour {

	public int sceneNum;					// scene level associated with puzzle
	public int puzzleID; 					// 0-Bulletin Board, 1-Desktop, 2-Drawer
	private bool puzzleDone;				// Is the associated puzzle complete?
	private GameController gameController;	//variable linking to game controller

	void Start () 
	{
		// finds and attaches game controller to script
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}
	
	void OnMouseOver()
	{
		if (Input.GetMouseButton (0)) 
		{
			// check if puzzle is complete
			puzzleDone = gameController.IsPuzzleDone (puzzleID);

			// if puzzle is not complete, allow scene change
			if(!puzzleDone)
			{
				Application.LoadLevel(sceneNum);
			}
		}
	}
}
