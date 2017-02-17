using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveBookInputs : MonoBehaviour {

	public InputField usernameInput;
	public string username;

	public int a = 0;

	void Start() {
		a++;
		if(username != null)
			usernameInput.text = username;
	}

	public void SaveUsername () {
		
	}
}
