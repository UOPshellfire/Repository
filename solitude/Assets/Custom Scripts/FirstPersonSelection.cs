﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstPersonSelection : MonoBehaviour {
	/*
	 * Will lock the mouse to center of the screen.
	 * Implement Ray Casting for detecting and selection
	 * We will add tags to our new objects to determine how they will reat to our selection.
	 */
	public float rayCastingLength;
	public Text interact;



	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		//default values
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray r = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
		Debug.DrawRay (r.origin, r.direction * rayCastingLength, Color.red); //will see the raycast in scene window
		if (Physics.Raycast(r, out hit, rayCastingLength)){
			if (hit.collider.tag == "EventTrigger" || hit.collider.tag == "Tomb" || hit.collider.tag == "Teleport")
			{
				interact.text = "Press 'E' to interact";
			}

			else
			{
				interact.text = "";
			}
		}

		if (Input.GetKeyDown(KeyCode.E)) { //value 0 is left mouse button
			if (Physics.Raycast(r, out hit, rayCastingLength)){
				if (hit.collider.tag == "EventTrigger" || hit.collider.tag == "Tomb" || hit.collider.tag == "Teleport"){
					hit.collider.GetComponent<InteractObject>().UpdateObject(hit.collider.tag, interact);
				}
			}
		}


	}
}
