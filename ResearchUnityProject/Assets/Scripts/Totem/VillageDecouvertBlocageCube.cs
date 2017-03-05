using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageDecouvertBlocageCube : MonoBehaviour {

	public GameObject Player;
	public GameObject MainCamera;
	GameObject CubeOnAss;
	GameObject CubeTotem;

	GameObject ScriptTotem;

	GameObject playerWrong;
	GameObject cam1;
	GameObject cam2;


	bool checkThisOnce;
	public bool VillageEstDeployer;

	bool didICheckThis;

	//public GameObject prefabCube;
	GameObject artefactNewCanvas;

	//public bool villageAnimLaunched;
	bool EnigmaResolving;
	bool didIInstantiate;

	GameManager GM;

	public EndTotemEnigma EndingTotemScript;

	//aniom de fin
	public Animator AnimFinTotem;
	bool animBool;
	public GameObject TopPart;
	public GameObject MidPart;
	public GameObject LowPart;
	public GameObject PilierCentralDeg;

	Transform RespawnEnigmeTotem;

	// Use this for initialization
	void Start () {
		//Player = GameObject.Find ("Player");
	//	CubeOnAss = GameObject.Find ("ArtefactOnAss");
		CubeTotem = GameObject.Find ("ActualCubeTotem");
		artefactNewCanvas = GameObject.Find ("ARtefactOverLayInteraction");
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager>();
		cam1 = GameObject.Find ("Main Camera Main");

		//LaunchCube = GameObject.Find ("InstantiateFromHere").GetComponent<Transform> ();

		CubeTotem.SetActive (false);
		didIInstantiate = false;
		RespawnEnigmeTotem = GameObject.Find ("RespawnEnigmeTotem").transform;
		EndingTotemScript = GameObject.Find ("EndGestionTotem").GetComponent<EndTotemEnigma>();
	}
	
	// Update is called once per frame
	void Update () {

	
		//si je viens d'arriver et que j'ai marcher dans le trigger oula le cube est bloqué il faut que je résolve l'énigme !!
		if (VillageEstDeployer && !checkThisOnce) {
			EnigmaResolving = true;
			checkThisOnce = true;
			CubeTotem.SetActive (true);
//			CubeOnAss.SetActive (false);
			//Player.GetComponent<DropCube> ().enabled = false;
		}

		if (EnigmaResolving && EndingTotemScript.EnigmaIsDone && !didICheckThis) {

			//Player.SetActive (true);
			//playerWrong = GameObject.Find ("CrounchingPlayerPuzzleTotem");
			//playerWrong.SetActive (false);
			//cam1.SetActive (true);
			//cam2 = GameObject.Find ("CameraEnigmeTotem");
			//cam2.SetActive (false);
			didICheckThis = true;

			//villageAnimLaunched = false;

		//	if (!didIInstantiate) {
				StartCoroutine ("AnimDeFinTotem");
		//	}
			//EnigmaResolving = false;
		}
	}

	IEnumerator AnimDeFinTotem(){
		//anim numéro 1 avec les totems qui bougent sur place

		//launchAnim
		//desactiverTopPartLowPartMidPart3DMLodele
		/*animBool = true;
		Player.SetActive (false);
		MainCamera.SetActive (false);
		AnimFinTotem.SetBool("ActivateFinTotem",animBool);

		TopPart.SetActive (false);
		MidPart.SetActive (false);
		LowPart.SetActive (false);
		PilierCentralDeg.SetActive (false);

		yield return new WaitForSeconds (10.3f);

		//anim numéro 2 montrer le joueur qui ramasse le cube
		animBool = false;
		Player.transform.position = RespawnEnigmeTotem.transform.position;
		AnimFinTotem.SetBool("ActivateFinTotem",animBool);
		yield return new WaitForSeconds (1.0f);

		artefactNewCanvas.SetActive (true);

		CubeTotem.SetActive (false);
		Player.SetActive (true);

		Player.GetComponent<DeathSystem> ().EnigmeActiveeMortSystemOn = false;
		yield return new WaitForSeconds (2.0f);

		//réactiver le joueur et le ramassage de cube.

		TopPart.SetActive (true);
		MidPart.SetActive (true);
		LowPart.SetActive (true);
		PilierCentralDeg.SetActive (true);

		MainCamera.SetActive (true);
		CubeOnAss.SetActive (true);
		CubeTotem.SetActive (false);
		GM.DesactiverChaudFroid ();
		//ScanningPanel.SetActive (true);

		//ScriptTotem = GameObject.Find ("ScriptTotem");
		//ScriptTotem.SetActive (false);*/

		Player.SetActive (true);
		Player.transform.position = RespawnEnigmeTotem.transform.position;
		GM.DesactiverChaudFroid ();
		Player.GetComponent<DeathSystem> ().EnigmeActiveeMortSystemOn = false;
//		artefactNewCanvas.SetActive (true);
		MainCamera.SetActive (true);
	//	CubeOnAss.SetActive (true);
		CubeTotem.SetActive (false);

		PilierCentralDeg.SetActive (false);
		yield return new WaitForSeconds (0.1f);

	}
}
