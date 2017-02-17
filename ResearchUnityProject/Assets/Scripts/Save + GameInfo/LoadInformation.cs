using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class LoadInformation : MonoBehaviour {

	public InputField usernameInput;
	public InputField DescriptionInput;

	public void LoadAll(){

		usernameInput.text = PlayerPrefs.GetString ("NAMEIMAGE1");
		DescriptionInput.text = PlayerPrefs.GetString ("DESCIMAGE1");

		//GameInformation.PlayerLevel = PlayerPrefs.GetInt ("PLAYERLEVEL");

	}
}