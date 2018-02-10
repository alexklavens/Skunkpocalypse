using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Skunks : MonoBehaviour {

	public Skunky _skunk;
	public int _counter = 0;
	public int _numSkunks;



	// Use this for initialization
	void Start () {

		//for loop for a certain number of skunks
		for (int i = 0; i < 30; i++) {
			//generate skunk at random position
			_makeSkunk();

		}

	}
	
	// Update is called once per frame
	void Update () {
		_counter++;
		/*if (_counter % 50 == 0) {
			_makeSkunk ();
		}*/

	}

	public void _makeSkunk(){
		int x = Random.Range (-35, 55);
		int y = Random.Range (-20, 18);
		Skunky newSkunk = Instantiate (_skunk, new Vector3 (x, y, 0), Quaternion.identity) as Skunky;
		_numSkunks++;
	}
		
}
