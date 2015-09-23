using UnityEngine;
using System.Collections;

//Script for camera mover in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class CameraMover : MonoBehaviour 
{
	public static int currentRotation = 270;		// var to hold camera rotation
													// for scene shifts

	public GameObject outButton;			// connects to out button
	public int outDir;						// camera direction that features out button
	public int deskDir;						// camera direction facing desk
	public int posterDir;					// camera direction facing poster
	private int prevRotation;				// holder for previous rotation

	static private bool begin = false;		// has the game begun?
	public GameObject deskEmitter;			// particle system for desk puzzle
	public UnityEngine.UI.Text title;		// game title text
	public GameObject blocker;				// blocker to prevent scene change before game has begun

	void Start()
	{
		// set camera rotation back to previous rotation before scene shift
		transform.rotation = Quaternion.Euler(0,currentRotation,0);
		currentRotation = (int)transform.eulerAngles.y;

		if (deskDir == currentRotation) {
			transform.Rotate(15,0,0);		// if facing desk, tilt down
		}

		// puzzle indicator off until game has begun
		deskEmitter.GetComponent<ParticleSystem>().enableEmission = false;

		if(begin) 	// if game has begun, turn on emitter, and turn off title
		{
			deskEmitter.GetComponent<ParticleSystem>().enableEmission = true;
			title.text = "";
			Invoke("KillBlocker",0f);
		}
	}

	void Update()
	{	
		// "out" button only active when facing exit
		outButton.SetActive (false);		
		if (outDir == currentRotation) {
			outButton.SetActive(true);
		} else {
			outButton.SetActive(false);
		}
		
		// player clicks screen to begin game
		if(Input.GetMouseButtonDown (0))
		{
			if(!begin)
			{
				deskEmitter.GetComponent<ParticleSystem>().enableEmission = true;
				title.text = "";
				Invoke("KillBlocker",1f);
				begin = true;
			}
		}
	}

	// function to be used by the GUI Buttons
	public void MoveCam (int deg) 
	{  
		prevRotation = currentRotation;
		// rotates camera per entered degrees on Button Control
		if(begin)
		{
			transform.Rotate(0,deg,0);
		}
		// sets the current rotation for the scene shifts
		currentRotation = (int)transform.eulerAngles.y;

		// to adjust for desk facing tilt
		if (deskDir == currentRotation) {
			transform.Rotate(15,0,0);
		} 
		if (prevRotation == deskDir){
			if(currentRotation == deskDir - 270){ 	// Right
				transform.Rotate(0,0,-15);
			} 
			if(currentRotation == deskDir - 90){ 	// Left
				transform.Rotate(0,0,15);
			}
		}

		// to adjust for poster facing tilt
		if (posterDir == currentRotation) {
			transform.Rotate(-25,0,0);
		} 
		if (prevRotation == posterDir){
			if(currentRotation == 180){ // Right
				transform.Rotate(0,0,25);
			} 
			if(currentRotation == 0){ 	// Left
				transform.Rotate(0,0,-25);
			}
		}
	}

	void KillBlocker()
	{
		Destroy (blocker);	// destroys blocker
	}



}
