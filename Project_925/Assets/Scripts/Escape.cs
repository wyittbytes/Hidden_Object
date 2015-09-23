using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Script for ending scene in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class Escape : MonoBehaviour 
{
	public Text escText;		// hit esc to escape
	public Text congratsText;	// congrats

	public Image ending;		// background image
	
	void Update () 
	{
		// if player hits esc button
		if(Input.GetKey (KeyCode.Escape))
		{
			// change to Mr. Pookums ending
			escText.text = "";
			congratsText.text = "GET BACK TO WORK!";
			Destroy(ending);
		}

		// if player clicks with mouse
		if(Input.GetMouseButtonDown(0))
		{
			Application.Quit();		// quit game
		}
	}
}
