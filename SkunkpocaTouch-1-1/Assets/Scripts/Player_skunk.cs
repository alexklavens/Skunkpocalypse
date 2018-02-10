using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TouchScript.Gestures;
using System;



public class Player_skunk : MonoBehaviour {

	public string leftKey = "left";
	public string rightKey = "right";
	public string upKey = "up";
	public string downKey = "down";

	public int _ammo = 100;
	public int _money = 10;
	public Camera _camera;
	public AudioClip _skunkHit;
	public int _health = 100;
	public int _score = 0;
	public float xDist = 0.0f;
	public float yDist = 0.0f;
	public float xVect = 0.0f;
	public float yVect = 0.0f;
	public float direction = 0.0f;
	//public Vector3 playerPos;
	public Text MoneyText;
	public Text AmmoText;
	public Text gameOverText;
	public Text HealthText;
	private bool isGameOver = false;

	//private Vector2 startPos = new Vector2();

	public GameObject _perfume;




	// Use this for initialization
	void Start () {
		HealthText.text = "100";
		AmmoText.text = "0";
		MoneyText.text = "10";
	}
	
	// Update is called once per frame
	void Update () {

		//float _move = .1f;
	
		//if (Input.GetKey (leftKey)) {
			
		//	transform.Translate (new Vector2 (-_move, 0));
		//} if (Input.GetKey (rightKey)) {
		//	transform.Translate (new Vector2 (_move, 0));
		//} if (Input.GetKey(upKey)){
		//	transform.Translate(new Vector2 (0,_move));
		//} if (Input.GetKey(downKey)){
		//	transform.Translate(new Vector2 (0,-_move));
		//}
		int speed = 5;
		transform.Translate(new Vector2 (xVect/speed, yVect/speed));

		//health
		if (_health < 1) {
			isGameOver = true;
			gameOverText.text = "Game Over";
			HealthText.text = "0";
			print ("GG");

		}
	}


	//*





	void OnCollisionEnter2D(Collision2D target){
		if ((target.gameObject.tag == "Skunk") && (_health > 0)) {
			_health = _health - 2;
			HealthText.text = _health.ToString();
			AudioSource.PlayClipAtPoint (_skunkHit, transform.position);
		}
		//else if ((target.gameObject.tag == "Finish") && (_health > 0)){
		//	isGameOver = true;
		//	gameOverText.text = "You Made It To Cummings";
		//}
		else if ((target.gameObject.tag == "Finish") && _health > 0){
			if (_money > 4){
			_ammo += 5;
			AmmoText.text = _ammo.ToString();
			_money -= 5;
			MoneyText.text = _money.ToString();
			}
		}
		else if (target.gameObject.tag == "Perfume"){
			Physics2D.IgnoreCollision (target.transform.GetComponent<Collider2D> (), this.transform.GetComponent<Collider2D> ());
		}

			
	}

	public int GetHealth(){
		return _health;
	}



	public Vector3 Position(){
		Vector3 pos = this.transform.position;
		return pos;
	}



	private Vector3 GetPlayerCoords (){
		Vector3 _playerCoords = this.transform.position;
		return _playerCoords;
	}

	public float GetX(){
		Vector3 _playerCoords = this.GetPlayerCoords();
		return _playerCoords [0];
	}

	public float GetY(){
		Vector3 _playerCoords = this.GetPlayerCoords();
		return _playerCoords [1];
	}

//	private void OnEnable(){
//		GetComponent<PressGesture> ().Pressed += pressedHandler;
//		GetComponent<ReleaseGesture> ().Released += releasedHandler;
//	}
//	private void OnDisable(){
//		GetComponent<PressGesture> ().Pressed -= pressedHandler;
//		GetComponent<ReleaseGesture> ().Released -= releasedHandler;
//	}
//
//	private void pressedHandler(object sender, EventArgs e)
//	{
//		//record press point
//		var gesture = sender as PressGesture;
//		startPos = gesture.NormalizedScreenPosition;
//		print (startPos);
//		//moving = true;
//		Debug.Log ("pressed");
//	}
//	private void releasedHandler(object sender, EventArgs e)
//	{
//		//moving = false;
//		// add force!
//		var gesture = sender as ReleaseGesture;
//		Vector2 force = gesture.NormalizedScreenPosition - startPos;
//		movePlayer (force[0], force[1]);
//		//GetComponent<Rigidbody2D>().AddForce (force*1.0f);
//		Debug.Log ("released");
//	}
	public void movePlayer(Vector3 tapPos)
	{
		Vector3 playerPos = this.transform.localPosition;
		playerPos = _camera.WorldToViewportPoint (playerPos);
		yDist = tapPos.y - playerPos.y;
		xDist = tapPos.x - playerPos.x;

		//Debug.Log (xDist);
		//Debug.Log (yDist);
		Debug.Log (tapPos.x);
		Debug.Log(tapPos.y);
		//Debug.Log(playerPos.x);
		//Debug.Log(playerPos.y);

		if (xDist > 0 && yDist > 0) {
			direction = (Mathf.Atan (yDist / xDist) * Mathf.Rad2Deg);

		} else if (xDist > 0 && yDist < 0) {
			direction = (Mathf.Atan (xDist / -yDist) * Mathf.Rad2Deg) + 270;

		} else if (xDist < 0 && yDist > 0) {
			direction = (Mathf.Atan (-xDist / yDist) * Mathf.Rad2Deg) + 90;

		} else {
			direction = (Mathf.Atan (yDist / xDist) * Mathf.Rad2Deg) + 180;

		}

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

	public void FireBall(Vector3 startPos, Vector3 endPos) {

		// instanticate a new ball from prefab at the position of the fakeball
		if (_ammo > 0){
		GameObject newPerfume = Instantiate(_perfume, this.transform.localPosition, Quaternion.identity) as GameObject;


		newPerfume.GetComponent<Perfume>().Vectors  (startPos, endPos);
		_ammo--;
		AmmoText.text = _ammo.ToString();
		// initial random speed (scalar value)
		//float angle = Mathf.Deg2Rad * Random.Range(240, 300);
		   
		// compute 2D force vector
		//Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

		// add force to newly created ball -> firing
		//newPerfume.GetComponent<Rigidbody2D>().AddForce(force * 0.4f);
		}


	}

}
