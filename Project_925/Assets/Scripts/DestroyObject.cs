using UnityEngine;
using System.Collections;

//Script for destroying puzzle objects in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class DestroyObject : MonoBehaviour {

	private PuzzleScript puzzleController;	// variable linking to puzzle controller
	public int objID;						// object ID to tie to label

	void Start () 
	{
		// finds and attaches puzzle controller to script
		GameObject puzzleControllerObject = GameObject.FindWithTag ("PuzzleController");
		if (puzzleControllerObject != null)	//if game controller exists
		{
			//connects to puzzle controller
			puzzleController = puzzleControllerObject.GetComponent<PuzzleScript>();
		}
		//if puzzle controller cannot be found prints error
		if (puzzleController == null)
		{
			Debug.Log("Cannot find 'PuzzleController' script");
		}
	}

	void OnMouseOver()
	{
		// when the player clicks on the item
		if (Input.GetMouseButton (0)) 
		{
			puzzleController.RemoveLabel(objID);	// remove from list
			gameObject.SetActive(false);			// and hide object
		}
	}
}
