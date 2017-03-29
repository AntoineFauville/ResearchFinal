using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	//public static int Gold{ get; set;}
	public static string NameImage1 {get; set;}
	public static string DescriptionImage1 {get; set;}
}
