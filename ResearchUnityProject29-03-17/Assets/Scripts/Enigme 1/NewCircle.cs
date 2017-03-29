using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCircle : MonoBehaviour {

	private const int 	IDLE = 0, //avant que le totem soit activé
	ANIMINTRO = 1, //l'anim de jonction, le joueur place l'artefact
	BLOQUER = 2,  //bloquage temporaire, le joueur doit résoudre l'énigme
	RESOLUTION = 3, //l'énigme est résolue, l'anim montre le joueur reprendre l'artefact
	IDLEFIN = 4; // le totem est terminer et on ne sait plus y acceder.


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
