using UnityEngine;
using System.Collections;

//Script for Mr. Pookums poster in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

// an Easter Egg of sorts

public class BewareMrPookums : MonoBehaviour {

	public UnityEngine.UI.Text msgText;	// grab UI text
	
	void Start () 
	{
		msgText.text = "";	// default to blank
	}
	
	void OnMouseOver()
	{
		if (Input.GetMouseButton (0)) 
		{
			msgText.text = ("GET BACK TO WORK!");
			Invoke("BlankText",1.5f);	// call blank
		}
	}

	void BlankText()
	{
		msgText.text = "";	// blank out text
	}
}
