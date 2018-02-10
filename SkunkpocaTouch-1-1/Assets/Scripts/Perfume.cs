using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfume : MonoBehaviour {

	//GameObject _perfume;

	public float direction = 0.0f;
	public float xVect = 0.0f;
	public float yVect = 0.0f;
	// Use this for initialization
	public float xDist = 0.0f;
	public float yDist = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < 10; i++) {
			//Debug.Log (xVect);
			int speed = 50;
		 	//transform.Rotate (new Vector3 (0, 0, 1), 0.1f);
			transform.Translate (new Vector2 (xVect / speed, 0), Space.World);
			transform.Translate (new Vector2 (0, yVect / speed), Space.World);


		}
		
	}
		
	void OnCollisionEnter2D(Collision2D target){
		if ((target.gameObject.tag == "Skunk")) {
			GameObject thePlayer = GameObject.Find("Player");
			Player_skunk playerScript = thePlayer.GetComponent<Player_skunk>();
			playerScript._money += 2;
			playerScript.MoneyText.text = playerScript._money.ToString();
			Destroy (target.gameObject);
			Destroy (this.gameObject);
		} else if ((target.gameObject.tag != "Player") && (target.gameObject.tag != "Collider") && (target.gameObject.tag != "Perfume")) {
			Destroy (this.gameObject);
		} else{
			Physics2D.IgnoreCollision (target.transform.GetComponent<Collider2D> (), this.transform.GetComponent<Collider2D> ());
		}

	}

	public void Vectors(Vector3 pressPoint, Vector3 releasePoint){
		

		yDist = releasePoint.y - pressPoint.y;
		xDist = releasePoint.x - pressPoint.x;
		if (xDist > 0 && yDist > 0) {
			direction = (Mathf.Atan (yDist / xDist) * Mathf.Rad2Deg);

		} else if (xDist > 0 && yDist < 0) {
			direction = (Mathf.Atan (xDist / -yDist) * Mathf.Rad2Deg) + 270;

		} else if (xDist < 0 && yDist > 0) {
			direction = (Mathf.Atan (-xDist / yDist) * Mathf.Rad2Deg) + 90;

		} else {
			direction = (Mathf.Atan (yDist / xDist) * Mathf.Rad2Deg) + 180;

		}

		//transform.Rotate(0.0f, 0.0f, special);

		if (direction > 270) {
			xVect = Mathf.Cos ((360 - direction) * Mathf.Deg2Rad);
			yVect = -Mathf.Sin ((360 - direction) * Mathf.Deg2Rad);
		} else if (direction > 180) {
			xVect = -Mathf.Cos ((direction - 180) * Mathf.Deg2Rad);
			yVect = -Mathf.Sin ((direction - 180) * Mathf.Deg2Rad);
		} else if (direction > 90) {
			xVect = -Mathf.Cos ((180 - direction) * Mathf.Deg2Rad);
			yVect = Mathf.Sin ((180 - direction) * Mathf.Deg2Rad);
		} else {
			xVect = Mathf.Cos (direction * Mathf.Deg2Rad);
			yVect = Mathf.Sin (direction * Mathf.Deg2Rad);
		}
	}
}
