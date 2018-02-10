using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class Joystick_script : MonoBehaviour {
	Boolean moving = false;
	private Vector2 startPos = new Vector2();
	Player_skunk _player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (moving){
		//	_player._movePlayer (this.transform.position[0], this.transform.position[1]);
		}
	}

	private void OnEnable(){
		GetComponent<PressGesture> ().Pressed += pressedHandler;
		GetComponent<ReleaseGesture> ().Released += releasedHandler;
	}
	private void OnDisable(){
		GetComponent<PressGesture> ().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture> ().Released -= releasedHandler;
	}


	private void pressedHandler(object sender, EventArgs e)
	{
		// record press point
		//var gesture = sender as PressGesture;
		//startPos = gesture.NormalizedScreenPosition;
		moving = true;
		Debug.Log ("pressed");
	}
	private void releasedHandler(object sender, EventArgs e)
	{
		moving = false;
		// add force!
		//var gesture = sender as ReleaseGesture;
		//Vector2 force = gesture.NormalizedScreenPosition - startPos;
		//GetComponent<Rigidbody2D>().AddForce (force*1.0f);
		Debug.Log ("released");
	}
}
