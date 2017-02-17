using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DetectableClass {

	public Vector3 pos;
	public string Name;
	//public GameObject Cercle;
	public bool isDetectedFarCircle;
	public bool isDetectedColdWarm;
	public bool hasBeenActivated;
	public enum Types
	{
		VILLAGE,
		TEMPLE,
		SMALL
	}


	public DetectableClass (Vector3 position, string NameOfTheGameObject, bool isDetected ,bool isDetectedCold, bool Activated){
		pos = position;
		Name = NameOfTheGameObject;
		isDetectedFarCircle = isDetected;
		isDetectedColdWarm = isDetectedCold;
		hasBeenActivated = Activated;
	}
}