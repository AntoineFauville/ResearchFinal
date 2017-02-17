using UnityEngine;
using System.Collections;

public class NavMeshMovingRock : MonoBehaviour {

	public Transform[] targets;
	UnityEngine.AI.NavMeshAgent agent;
	public int i = 0;

	public float dist;

	public bool returnAxis = false;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = targets [i].transform.position;
	}

	void Update () {
		dist = Vector3.Distance (targets [i].transform.position, transform.position);
		if (dist < 0.2f) {

			//+++ positive part
			//1 increment i
			if (Input.GetAxis ("Horizontal") >= 0.7f && !returnAxis) {
				i++;
				returnAxis = true;
				StartCoroutine ("returnAxisCoroutine");
				//2 check if i is less than target length
				if (i < targets.Length) {
					agent.destination = targets [i].transform.position;
				}
			}
			//--- negative part
			//1 decrease i
			else if (Input.GetAxis ("Horizontal") <= -0.7f && !returnAxis) {
				i--;
				returnAxis = true;
				StartCoroutine ("returnAxisCoroutine");
				//2 as long as i bigger than 0 set destination
				if (i >= 0) {
					agent.destination = targets [i].transform.position;
				}
			}

			//3 if i = target.length
			//because we go in positif, no reason to put condition for less than 0.
			if (i == targets.Length)	{
				i = 0;
				agent.destination = targets [i].transform.position;
			}

			//3 if i less than 0 => target lenght -1
			if (i < 0)	{
				i = targets.Length-1;
				agent.destination = targets [i].transform.position;
			}
		}


		if (i < 0)	{
			i = targets.Length;
			//if (!returnAxis) {
				returnAxis = true;
				StartCoroutine ("returnAxisCoroutine");
				agent.destination = targets [i].transform.position;
			//}
		}
	}

	IEnumerator returnAxisCoroutine () {
		yield return new WaitForSeconds (1.0f);
		returnAxis = false;
	}
}

/*if(dist < 0.1f){
			i++;
			if(i < targets.Length)	{
				agent.destination = targets [i].transform.position;
			}
		}*/