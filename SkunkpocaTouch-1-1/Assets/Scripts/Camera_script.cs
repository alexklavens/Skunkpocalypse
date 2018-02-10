using UnityEngine;
using System.Collections;

public class Camera_script : MonoBehaviour {

	public Player_skunk _player;
	public float _move = .1f;

	// Use this for initialization
	void Start () {
	
	}



	//This works for FOV = 51 and Z = -16.37

	void Update () {

		float playerX = _player.GetX ();
		float playerY = _player.GetY ();

		float cameraX = this.GetCameraX ();
		float cameraY = this.GetCameraY ();
		float cameraZ = this.GetCameraZ ();

		float posDifX = GetDif (playerX, cameraX);
		float posDifY = GetDif (playerY, cameraY);

		for (int i = 0; i < 2; i++) {

			if (Mathf.Abs (posDifX) >= 5) {
				if (posDifX > 0) {
					transform.Translate (new Vector3 (_move, 0, 0));
				} else {
					transform.Translate (new Vector3 (-_move, 0, 0));
				}
			}
			if (Mathf.Abs (posDifY) >= 5) {
				if (posDifY > 0) {
					transform.Translate (new Vector3 (0, _move, 0));
				} else {
					transform.Translate (new Vector3 (0, -_move, 0));
				}
			}
		}

	}

	public float GetDif(float a, float b){
		return a-b;
	}

	public Vector3 GetCameraCoords(){
		Vector3 _cameraCoords = this.transform.position;
		return _cameraCoords;
	}


	public float GetCameraX(){
		Vector3 _cameraCoords = GetCameraCoords ();
		return _cameraCoords [0];
	}

	public float GetCameraY(){
		Vector3 _cameraCoords = GetCameraCoords ();
		return _cameraCoords [1];
	}

	public float GetCameraZ(){
		Vector3 _cameraCoords = GetCameraCoords ();
		return _cameraCoords [2];
	}


}
