using UnityEngine;
using System.Collections;

public class Skunky : MonoBehaviour {

	public float direction = 0.0f;
	public float xVect = 0.0f;
	public float yVect = 0.0f;
	// Use this for initialization
	public float xDist = 0.0f;
	public float yDist = 0.0f;

	//public GameObject _player;
	public Vector3 playerPos;
	public Vector3 skunkPos;
	public float bs;
	public int _frameCount = 0;
	public int _life = 3;

	//public gameObject _part = gameObject.GetComponent<ParticleSystem>




	void Start () {

	}


	
	// Update is called once per frame
	void Update () {

		if ((_frameCount % 100) == 0) {
			Vectors ();
		}
			
		for (int i = 0; i < 10; i++) {
			int speed = 200;
			transform.Translate (new Vector2 (xVect / speed, 0));
			transform.Translate (new Vector2 (0, yVect / speed));
		}
		
	}
	void Vectors(){
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		skunkPos = this.transform.position;
		if (Vector3.Distance (playerPos, skunkPos) < 4	) {
			yDist = playerPos.y - skunkPos.y;
			xDist = playerPos.x - skunkPos.x;
			if (xDist > 0 && yDist > 0) {
				direction = (Mathf.Atan (xDist / yDist) * Mathf.Rad2Deg);

			} else if (xDist > 0 && yDist < 0) {
				direction = (Mathf.Atan (xDist / -yDist) * Mathf.Rad2Deg) + 270;

			} else if (xDist < 0 && yDist > 0) {
				direction = (Mathf.Atan (-xDist / yDist) * Mathf.Rad2Deg) + 90;

			} else {
				direction = (Mathf.Atan (xDist / yDist) * Mathf.Rad2Deg) + 180;

			}
		} else {
			int special = Random.Range (-15, 15);
			direction += special;
			if (direction < 0) {
				direction += 360;
			} else if (direction > 360) {
				direction -= 360;
			}
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
