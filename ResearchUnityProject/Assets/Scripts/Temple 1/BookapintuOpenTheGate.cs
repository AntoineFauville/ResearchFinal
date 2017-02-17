using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookapintuOpenTheGate : MonoBehaviour {

	public GameObject wall;

	public Image refimage;

	public float amout;

	public bool enigma1DoneB;
	public bool enigma2DoneB;
	public bool enigma3DoneB;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		amout = refimage.fillAmount;

		if (amout >= 0.7f && enigma1DoneB && enigma2DoneB && enigma3DoneB) {
			wall.SetActive (false);
		}
	}
}
