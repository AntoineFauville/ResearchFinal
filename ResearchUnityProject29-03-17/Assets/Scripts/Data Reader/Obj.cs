using System.Collections;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Obj {
	
	[XmlAttribute("name")]
	public string name;

	[XmlElement("Desc")]
	public string desc;
}