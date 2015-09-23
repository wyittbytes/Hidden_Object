using UnityEngine;
using System.Collections;

//Script for destroying devices in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class DestroyDevice : MonoBehaviour {


	public int deviceID;					//	1 = phone, 2 = computer
	private GameController gameController;	// variable linking to game controller
	private bool prizeWon;					// does the player have implement of destruction?

	// Use this for initialization
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
			// check to see if player has implement
			prizeWon = gameController.IsPuzzleDone (deviceID);

			if(prizeWon)	// if the player does
			{
				// disable in game controller script
				gameController.DisableDevice(deviceID);	
				Destroy(gameObject);	// and destroy the device
			}
		}
	}
}
