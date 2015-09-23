using UnityEngine;
using System.Collections;

//Script for drawer handle change in Escaping Cube 925
//GADA243 - Sp15 - T. Wyitt Carlile

public class Usable : MonoBehaviour {

	public Material defaultMaterial;	// starting material
	public Material glowMaterial;		// glowing material
	public Material inactiveMaterial;	// back to starting material
	
	private bool itemUsable = true;		// is the object usable?

	void Start () 
	{
		// initialize default material
		renderer.material = new Material (defaultMaterial);
	}

	void FixedUpdate () 
	{
		// change the render material back to default
		renderer.material = defaultMaterial;

		if(!itemUsable) // if the item no longer in use
		{				// go to inactive material
			renderer.material = inactiveMaterial;
		}
			
		if (OpenDrawer.isOpen) // if the drawer is open
		{
			itemUsable = false;	// it is not longer usable
		}
	}
	
	void OnMouseOver()
	{
		// if moused over and usable, change to glow material
		if(itemUsable)
		{
			renderer.material = glowMaterial;
		}
	}

}
