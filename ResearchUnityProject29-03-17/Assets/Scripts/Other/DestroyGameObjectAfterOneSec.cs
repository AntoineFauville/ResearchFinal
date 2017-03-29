using UnityEngine;
using System.Collections;

public class DestroyGameObjectAfterOneSec : MonoBehaviour {

	public float v; 

	void Start () {
		Destroy (gameObject, v);
	}
}