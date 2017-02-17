using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveStates : MonoBehaviour {
	
	//public bool[] Objectives;
	public GameObject[] Triggers;
	public Animator[] CanvasAnimator;
	public Animator PlayerCanvas;

	public bool[] objectivesBool;

	bool newObjectivePlayerUI = false;

	public int i = 0;

	void Update () {
		CanvasAnimator [i].SetBool ("NewObjective",objectivesBool[i]);
		if (i > 0) {
			CanvasAnimator [i-1].SetBool ("NewObjective",objectivesBool[i-1]);
		}

		PlayerCanvas.SetBool ("NewObjectiveActiv",newObjectivePlayerUI);

	//	print (newObjectivePlayerUI);
	}

	public void GoNextPoint(int a){
		i = a;

		Triggers [i].SetActive (false);
		Triggers [i+1].SetActive (true);

		objectivesBool [i] = true;

		if (i > 0) {
			objectivesBool [i - 1] = false;
		}

		StartCoroutine ("returnAfterOneSec");

	}

	IEnumerator returnAfterOneSec () {
		newObjectivePlayerUI = true;
		yield return new WaitForSeconds (0.5f);
		newObjectivePlayerUI = false;
	}
}
