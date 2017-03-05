using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMapController : MonoBehaviour {

	GameObject Player;
	Vector3 TempPlayerPos;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//position
		TempPlayerPos = Player.transform.position;
		this.transform.position = new Vector3 (TempPlayerPos.x,this.transform.position.y,TempPlayerPos.z);

		//rotation mais seulement en y

		//float actualXCam = Player.transform.rotation.eulerAngles.x;
		float actualYCam = Player.transform.rotation.eulerAngles.y;
		//float actualZCam = Player.transform.rotation.eulerAngles.z;

		float actualXPla = transform.rotation.eulerAngles.x;
		//float actualYPla = transform.rotation.eulerAngles.y;
		float actualZPla = transform.rotation.eulerAngles.z;

		//Player.transform.rotation = Quaternion.Euler (actualXCam,actualYCam,actualZCam);
		transform.rotation = Quaternion.Euler (actualXPla,actualYCam,actualZPla);
	}
}
