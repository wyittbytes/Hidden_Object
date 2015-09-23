using UnityEngine;
using System.Collections;

//Script for drawer in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class OpenDrawer : MonoBehaviour {

	private GameController gameController;	// variable linking to game controller
	private string[] m_AnimNames;			// variable to hold animations

	private bool puzzleDone;				// has the puzzle been completed
	private bool hasKey;					// does the player have the key
	static public bool isOpen = false;		// is the drawer open?
	static public bool hasClosed = false;	// has the drawer been closed?

	public GameObject drawerEmitter;		// particle system for puzzle indicator

	public int puzzleID = 2;				// puzzle id num

	void Start () 
	{
		// finds and attaches game controller to script
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();

		drawerEmitter.GetComponent<ParticleSystem>().enableEmission = false;

		// assigns the attached animations to the script
		m_AnimNames = new string[animation.GetClipCount()]; // initializes animation array
		int index = 0;										// index for loop 
		foreach(AnimationState anim in animation)			// loop to populate the array
		{
			m_AnimNames[index] = anim.name;					// add animation to array
			index++;										// incriment index
		}

		if (isOpen)	// if the drawer is open, skip animation and turn on emitter
		{
			animation[m_AnimNames[0]].time = 1.0f;
			animation[m_AnimNames[0]].speed = 0.0f;
			animation.Play(m_AnimNames[0]);
			drawerEmitter.GetComponent<ParticleSystem>().enableEmission = true;
		}
		if (hasClosed)	// if the drawer is closed, skip animation and turn off emitter
		{
			animation[m_AnimNames[1]].time = 1.0f;
			animation[m_AnimNames[1]].speed = 0.0f;
			animation.Play(m_AnimNames[1]);
			drawerEmitter.GetComponent<ParticleSystem>().enableEmission = false;
		}

	}

	void Update () 
	{
		// check to see if puzzle is done
		puzzleDone = gameController.IsPuzzleDone (puzzleID);
		// check to see if player has key
		hasKey = gameController.ShowKey ();

		if (puzzleDone)	// if puzzle is done...
		{
			if(!hasClosed)	//...and the drawer isn't closed
			{
				animation.Play (m_AnimNames[1]);	// close drawer
				hasClosed = true;					// and turn off emitter
				drawerEmitter.GetComponent<ParticleSystem>().enableEmission = false;
			}
		}
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButton (0)) 
		{
			if(!isOpen && hasKey)	// if the drawer isn't open & player has key
			{
				animation.Play (m_AnimNames[0]); // open drawer and turn on emitter
				drawerEmitter.GetComponent<ParticleSystem>().enableEmission = true;
				isOpen = true;
			}
		}
	}

}


