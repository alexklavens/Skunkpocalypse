using UnityEngine;
using System.Collections;

public class Enterance : MonoBehaviour {


	//building that the enterance is attached to
	public Building_script building1;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player") {
			//Transform _ignorePlayer = Instantiate (Player_skunk) as Transform;
			Physics2D.IgnoreCollision (target.transform.GetComponent<Collider2D> (), this.transform.GetComponent<Collider2D> ());
		}



	}
}
