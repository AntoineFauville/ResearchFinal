using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HistorybarInteractive : MonoBehaviour {

	public float actualAmout;
	public Image barRecherche;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		actualAmout = barRecherche.fillAmount;
	}
}