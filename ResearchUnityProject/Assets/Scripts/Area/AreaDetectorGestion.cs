using UnityEngine;
using System.Collections;

public class AreaDetectorGestion : MonoBehaviour {
	/*
	/*public DetectArea area1Script;
	public DetectArea area2Script;
	public DetectArea area3Script;
	public DetectArea area4Script;
	public DetectArea area5Script;
	public DetectArea area6Script;
	public DetectArea area7Script;
	public DetectArea area8Script;
	public DetectArea area9Script;
	public DetectArea area10Script;
	public DetectArea area11Script;*/
	/*
	public bool area1;

	public GameObject player;

	public float modificationSpeedArea1;
	public float AnimModificationSpeed;
	public float speedBeforeEntering;

	public float amoutOfMoveSpeed;

	// Use this for initialization
	/*void Start () {
		speedBeforeEntering = player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier;
	}
	
	// Update is called once per frame
	/*void Update () {
		/*if (area1Script.amIArea1 == true || area2Script.amIArea1 == true || area3Script.amIArea1 == true || area4Script.amIArea1 == true || area5Script.amIArea1 == true
			|| area6Script.amIArea1 == true || area7Script.amIArea1 == true || area8Script.amIArea1 == true || area9Script.amIArea1 == true || area10Script.amIArea1 == true
			|| area11Script.amIArea1 == true) {

			area1 = true;
		}

		if (area1Script.amIArea1 == false && area2Script.amIArea1 == false && area3Script.amIArea1 == false && area4Script.amIArea1 == false && area5Script.amIArea1 == false
			&& area6Script.amIArea1 == false && area7Script.amIArea1 == false && area8Script.amIArea1 == false && area9Script.amIArea1 == false && area10Script.amIArea1 == false
			&& area11Script.amIArea1 == false) {
			
			area1 = false;
		}*/



	/*	if (player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_AnimSpeedMultiplier <= 0.4f) {
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_AnimSpeedMultiplier = 0.4f;
		}

		if (player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier <= 0.6f) {
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier = 0.6f;
		}

		amoutOfMoveSpeed = player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier;


		//stock actualspeed to put it back later on

			if (area1) {
				player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier -= modificationSpeedArea1 * Time.deltaTime;
				player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_AnimSpeedMultiplier -= AnimModificationSpeed * Time.deltaTime;

			}
			
		if (!area1 && player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier <= speedBeforeEntering) {
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier += modificationSpeedArea1 * 3 * Time.deltaTime;
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_AnimSpeedMultiplier += AnimModificationSpeed * Time.deltaTime;
		}

		if (!area1 && player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier >= speedBeforeEntering) {
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_MoveSpeedMultiplier = speedBeforeEntering;
			player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().m_AnimSpeedMultiplier = speedBeforeEntering;
		}
	}*/
}
