using UnityEngine;
using System.Collections;

public class LightBeamTriggerLazer : MonoBehaviour {

	public Transform trans;
	Vector3 dist;

	void Start(){
		StartCoroutine ("UpdateTine");
	}

	void upday() 
	{
		dist = transform.TransformDirection (trans.position);
		StartCoroutine ("UpdateTine");
	}	

	void OnDrawGizmosSelected () {
	
		Gizmos.color = Color.green;
		Gizmos.DrawRay (transform.position, dist);
	}

	IEnumerator UpdateTine () {
		yield return new WaitForSeconds (1.0f);
		upday();
	}
}
