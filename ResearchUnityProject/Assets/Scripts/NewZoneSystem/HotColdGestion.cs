using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotColdGestion : MonoBehaviour {

	GameManager GM;
	Animator anim;
	QT_SurfaceNoise2 QTSurfShad;

	// Use this for initialization
	void Start () {
		GM = this.gameObject.GetComponent<GameManager> ();
		anim =  GameObject.Find ("ArtefactAnimation").GetComponent<Animator>();
		QTSurfShad = GameObject.Find ("artefactNewCanvasChaudFroid").GetComponent<QT_SurfaceNoise2>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.hotcold) {
			ChangeStateShader ();
		} else {
			ChangeStateShaderReset ();
		}
	}

	void ChangeStateShader(){
/*		QTSurfShad.scaleModifier = (GM.distanceChaudFroid - GM.distance)/4;
		QTSurfShad.speedModifier = (GM.distanceChaudFroid - GM.distance)/4;
		QTSurfShad.noiseStrength = (GM.distanceChaudFroid - GM.distance) / GM.distanceChaudFroid/2;

		anim.speed = (GM.distanceChaudFroid - GM.distance) / (GM.distanceChaudFroid/4);*/
	}

	void ChangeStateShaderReset(){
		QTSurfShad.scaleModifier = 0;
		QTSurfShad.speedModifier = 0;
		QTSurfShad.noiseStrength = 0;
		anim.speed = 1.0f;
	}
}
