using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTotemEnigma : MonoBehaviour {

	public Quaternion actual1;

	bool gotThisOnce;

	public GameObject TopPart;
	public GameObject MidPart;
	public GameObject DownPart;

	public GameObject TopPartScript;
	public GameObject MidPartScript;
	public GameObject DownPartScript;

	public GameObject TopOutLineTotem;
	public GameObject MidOutLineTotem;
	public GameObject DownOutLineTotem;

	public bool EnigmaIsDone;

	public GestionSelectionParts GSP;

	//public TriggerSendingInfoTotem1 Trigger01;
	//public TriggerSendingInfoTotem2 Trigger02;

	void Start () {
		//Trigger01 = GameObject.Find ("TriggerForResolution01").GetComponent<TriggerSendingInfoTotem1>();
		//Trigger02 = GameObject.Find ("TriggerForResolution02").GetComponent<TriggerSendingInfoTotem2>();

		//TopOutLineTotem = GameObject.Find ("TopPartOutlineTotem");
		//MidOutLineTotem = GameObject.Find ("MiddlePartOutlineTotem");
		//DownOutLineTotem = GameObject.Find ("DownPartOutlineTotem");

		//TopPartScript = GameObject.Find ("PartTopGestionTotem");
		//MidPartScript = GameObject.Find ("PartMidGestionTotem");
		//DownPartScript = GameObject.Find ("PartDownGestionTotem");

		//GSP = GameObject.Find ("GestionPartSelectionTotem").GetComponent<GestionSelectionParts>();
	}

	// Update is called once per frame
	void Update () {
		
		Quaternion currentRotationPart2 = (MidPart.transform.rotation);
		Quaternion currentRotationPart3 = (DownPart.transform.rotation);

		float rot2 = Mathf.Abs (currentRotationPart2.y);
		float rot3 = Mathf.Abs (currentRotationPart3.y);

		//if (Trigger01.GoodToGoTotem01 && Trigger02.GoodToGoTotem02 && !gotThisOnce) {
		if(rot2 == 1.0f && rot3 == 1.0f  && !gotThisOnce){
			EnigmaIsDone = true;

			TopPartScript.GetComponent<AnimTopPartNotMoving> ().enabled = false;
			MidPartScript.GetComponent<RotationEnigmeLazer> ().enabled = false;
			DownPartScript.GetComponent<RotationEnigmeLazer> ().enabled = false;

			GSP.state1 = false;
			GSP.state2 = false;
			GSP.state3 = false;

			TopOutLineTotem.SetActive (false);
			MidOutLineTotem.SetActive (false);
			DownOutLineTotem.SetActive (false);

			GSP.enabled = false;

			print ("EnigmaTotemDone");
			gotThisOnce = true;
		//	}
		}
	}
}
