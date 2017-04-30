using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeManager : MonoBehaviour {

	public int[] number;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < number.Length; i++) {
			number [i] = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < number.Length; i++) {
			if (number [i] > 3) {
				number [i] = 1;
			}
		}
	}

	public void IncrementOne () {
		number [0] += 1;
	}

	public void IncrementTwo () {
		number [1] += 1;
	}

	public void IncrementThree () {
		number [2] += 1;
	}

	public void IncrementFour () {
		number [3] += 1;
	}
}
