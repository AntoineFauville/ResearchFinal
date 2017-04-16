using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjTextReader : MonoBehaviour {

	public Text textName;
	public Text textDesc;

	public int NumberOfTheObject;

	public const string path = "Obj";

	// Use this for initialization
	void Awake ()
	{


		ObjContainer ObjContain = ObjContainer.Load (path);

		textName.text = ObjContain.objs [NumberOfTheObject].name;
		textDesc.text = ObjContain.objs [NumberOfTheObject].desc;
	}
}
