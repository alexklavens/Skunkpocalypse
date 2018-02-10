using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour {

	public Camera_script _camera;
	public Text gameOverText;
	private bool isGameOver = false;

	public Player_skunk _player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {




	}

//	public void SetBarPosX(){
//		float cameraX = _camera.GetCameraX();
//		float barX = GetBarX();
//
//			
//	}
//
//
//
//
//
//
//
//	public Vector3 GetBarCoords(){
//		Vector3 _barCoords = this.transform.position;
//		return _barCoords;
//	}
//
//	public float GetBarX(){
//		Vector3 _barCoords = GetBarCoords ();
//		return _barCoords [0];
//	}
//
//	public float GetBarY(){
//		Vector3 _barCoords = GetBarCoords ();
//		return _barCoords [1];
//	}
//
//	public float GetBarZ(){
//		Vector3 _barCoords = GetBarCoords ();
//		return _barCoords [2];
//	}
		
}
