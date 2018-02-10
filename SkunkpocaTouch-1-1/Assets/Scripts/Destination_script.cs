using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination_script : MonoBehaviour {

	public goal_script _first;
	public goal_script _second;
	public goal_script[] _goals;
	public int _isOn = 0;


	// Use this for initialization
	void Start (){
		_goals = new goal_script[2] { _first, _second };
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_isOn%2 == 0) {
			_first.gameObject.SetActive (true);
			_second.gameObject.SetActive (false);
		} else if (_isOn%2 == 1) {
			_first.gameObject.SetActive (false);
			_second.gameObject.SetActive (true);
		} 	
	}
	public void increase(int _inc){
			_isOn += _inc;
	}
}
