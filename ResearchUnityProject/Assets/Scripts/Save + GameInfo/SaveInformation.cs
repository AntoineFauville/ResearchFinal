using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class SaveInformation : MonoBehaviour {

	public InputField usernameInput;
	public InputField DescriptionInput;

	public void SaveName(){

		GameInformation.NameImage1 = usernameInput.text;

		PlayerPrefs.SetString ("NAMEIMAGE1", GameInformation.NameImage1); 
		//PlayerPrefs.SetInt ("CURRENTXP", GameInformation.CurrentXP);

		Debug.Log ("SAVED NAME IMAGE 1");
		}

	public void SaveDesc(){

		GameInformation.DescriptionImage1 = DescriptionInput.text;

		PlayerPrefs.SetString ("DESCIMAGE1", GameInformation.DescriptionImage1); 
		//PlayerPrefs.SetInt ("CURRENTXP", GameInformation.CurrentXP);

		Debug.Log ("SAVED DESC IMAGE 1");
	}
}