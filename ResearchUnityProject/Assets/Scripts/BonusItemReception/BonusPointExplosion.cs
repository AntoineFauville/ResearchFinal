using UnityEngine;
using System.Collections;

public class BonusPointExplosion : MonoBehaviour {

	public GameObject Prefab;

	public float secondBetweenBalls = 1f;

	public bool bonusReceived;
	public bool playerishere;

	public int amoutofballs = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerishere) {
			bonusReceived = true;
			playerishere = false;
			StartCoroutine("secBetweenInstantiate");
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player" && !bonusReceived) {
			playerishere = true;
		}
	}

	IEnumerator secBetweenInstantiate () {
		for (int i = 0; i < amoutofballs; i++) {
			yield return new WaitForSeconds (secondBetweenBalls);
			Instantiate (Prefab, transform.position, transform.rotation);
			i++;
		}
	}
}
