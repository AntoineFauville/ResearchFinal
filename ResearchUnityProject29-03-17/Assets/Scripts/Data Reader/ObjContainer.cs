using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("ObjCollection")]
public class ObjContainer {

	[XmlArray("Objs")]
	[XmlArrayItem("Obj")]
	public List<Obj> objs = new List<Obj>();

	public static ObjContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset> (path);

		XmlSerializer serializer = new XmlSerializer (typeof(ObjContainer));

		StringReader reader = new StringReader (_xml.text);

		ObjContainer objs = serializer.Deserialize (reader) as ObjContainer;

		reader.Close ();

		return objs;
	}
}
