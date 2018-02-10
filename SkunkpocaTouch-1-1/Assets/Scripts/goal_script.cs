using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_script : MonoBehaviour {

	public Destination_script _parent;

	

	// Use this for initialization
	void Start () {
		//gameObject.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player") {
			Debug.Log ("destroyed");
			_parent.increase(1);
		}
	}


}
