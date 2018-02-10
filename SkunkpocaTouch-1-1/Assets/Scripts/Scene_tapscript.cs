using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class Scene_tapscript : MonoBehaviour {

	public Player_skunk _player;
	//public Vector2 startPos = new Vector2();
	// Use this for initialization

	public Vector3 startPos;
	public Vector3 touchDist = new Vector3(.1f,.1f,.1f);


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player" || target.gameObject.tag == "Skunk") {
			//Transform _ignorePlayer = Instantiate (Player_skunk) as Transform;
			Physics2D.IgnoreCollision (target.transform.GetComponent<Collider2D> (), this.transform.GetComponent<Collider2D> ());
		}



	}

	private void OnEnable(){
		Debug.Log ("On Enable");


		GetComponent<PressGesture> ().Pressed += pressedHandler;
		GetComponent<ReleaseGesture> ().Released += releasedHandler;
		//GetComponent<TapGesture>().Tapped += tappedHandler;

	}

	private void OnDisable(){
		Debug.Log ("On Disable");


		GetComponent<PressGesture> ().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture> ().Released -= releasedHandler;
		//GetComponent<TapGesture>().Tapped += tappedHandler;
	}
		
	private void tappedHandler(object sender, EventArgs e){
		
		var gesture = sender as TapGesture;
		//Debug.Log (gesture);
		 startPos = gesture.NormalizedScreenPosition;
		Debug.Log("Tap");

		//Debug.Log ("start pos");
		//Debug.Log(startPos);
		_player.movePlayer (startPos);
	}

	private void pressedHandler(object sender, EventArgs e)
	{
		// record press point
		var gesture = sender as PressGesture;
		startPos = gesture.NormalizedScreenPosition;
		Debug.Log ("pressedHandler");
	}
	private void releasedHandler(object sender, EventArgs e)
	{
		Debug.Log ("releasedHandler");
		// add force!
		var gesture = sender as ReleaseGesture;
		Vector3 endPos = gesture.NormalizedScreenPosition;

		//float xDif = endPos [1] == startPos [1];
		//float yDif = endPos [1] == startPos [1];



		if (Vector3.Distance(startPos,endPos) <= .02) {
			_player.movePlayer (startPos);
			Debug.Log ("movePlayer if statement entered");
		} else {
			_player.FireBall (startPos, endPos);
			Vector3 force = endPos - startPos;
		//	GetComponent<Rigidbody2D>().AddForce (force*1.0f);
			Debug.Log ("else statement in released handler");
		}
	}

	//pressrelease

	//in update, if pressed point == released point, do move
	//if press point != released point, fire object
}
