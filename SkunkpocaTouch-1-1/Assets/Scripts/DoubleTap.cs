using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TouchScript.Gestures;

public class DoubleTap : MonoBehaviour {

	public Player_skunk _player;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player" || target.gameObject.tag == "Skunk" || target.gameObject.tag == "Colider") {
			//Transform _ignorePlayer = Instantiate (Player_skunk) as Transform;
			Physics2D.IgnoreCollision (target.transform.GetComponent<Collider2D> (), this.transform.GetComponent<Collider2D> ());
		}



	}

	private void OnEnable(){
		Debug.Log ("On Enable");

		GetComponent<TapGesture>().Tapped += tappedHandler;


	}

	private void OnDisable(){
		Debug.Log ("On Disable");

		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void tappedHandler(object sender, EventArgs e){

		var gesture = sender as TapGesture;
		//Debug.Log (gesture);
		Vector3 startPos = gesture.NormalizedScreenPosition;

		//Debug.Log ("start pos");
		//Debug.Log(startPos);
		Debug.Log("doubleTap");
		//_player.movePlayer (startPos);
	}

}
