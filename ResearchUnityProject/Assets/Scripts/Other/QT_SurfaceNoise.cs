using UnityEngine;
using System.Collections;

public class QT_SurfaceNoise : MonoBehaviour
{
    float scale;
	public float scaleModifier;
    float speed;
	public float speedModifier;
    public float noiseStrength = 0.1f;
	public float UpdateFrequency=.05f;

    MeshFilter mf = new MeshFilter();

	SanityGestion SG;

    Vector3[] baseHeight;
    Vector3[] newVerts;

	float rand;
	float randScale;
	float randSpeed;

    void Start()
    {
		rand = Random.Range (noiseStrength - 0.02f, noiseStrength + 0.02f);
		randScale = Random.Range (scaleModifier - 0.5f, scaleModifier + 0.5f);
		randSpeed = Random.Range (speedModifier - 0.5f, speedModifier + 0.5f);


		SG = GameObject.Find ("Player").GetComponent<SanityGestion> ();

        mf = this.GetComponent<MeshFilter>();
       // mesh = mf.mesh;
        baseHeight = mf.mesh.vertices;
        newVerts = new Vector3[baseHeight.Length];
		StartCoroutine(DoWave());
    }

	IEnumerator DoWave()
	{
		while(true)
		{
			for (var i=0;i<newVerts.Length;i++)
			{

				scale = (scaleModifier * 1- SG.sanity) * randScale;
				speed = (speedModifier * 1 - SG.sanity) * randSpeed;

				noiseStrength = 0.1f + rand;

				Vector3 vertex = baseHeight[i];
				
				float s = (Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
				float finalVal = Mathf.Sin(1.25f * s) * noiseStrength;//(Mathf.Sin(s) + Mathf.Sin(1.25f * s)) * noiseStrength;

				vertex.y += finalVal;
				vertex.x += finalVal;
				vertex.z += finalVal;


				newVerts[i] = vertex;
			}
			mf.mesh.vertices = newVerts;
			mf.mesh.RecalculateNormals();
			
			yield return new WaitForSeconds(UpdateFrequency);			

		}
	}
    
}
    
