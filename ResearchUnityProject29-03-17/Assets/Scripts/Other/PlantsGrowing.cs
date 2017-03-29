using UnityEngine;
using System.Collections;

public class PlantsGrowing : MonoBehaviour {

	public GameObject[] plantList;
	public bool grow;

	public float growingSpeed = 0.05f;
	public float finalSize = 1;
	public float len;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < plantList.Length; i++)
			plantList [i].transform.localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (grow) {
			for (int i = 0; i < plantList.Length; i++) {
				plantList [i].transform.localScale = new Vector3 (len, len, len);
				len += growingSpeed;
			}
		}

		if (len >= finalSize) {
			grow = false;
		}
	}
	void OnTriggerEnter (Collider coll){
		if (coll.tag == "Player") {
			grow = true;
		}
	}
}
