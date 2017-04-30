using UnityEngine;
using System.Collections;

public class ScannerEffect : MonoBehaviour
{
	public Transform ScannerOrigin;
	public Material EffectMaterial;
	public float ScanDistance;
	public float secAutoScan;

	bool 
	go,
	canUse;

	private Camera _camera;

	// Demo Code
	bool _scanning;
	Scannable[] _scannables;

	void Start()
	{
		_scannables = FindObjectsOfType<Scannable>();
    }

	void Update()
	{
		if (_scanning)
		{
			//ScanDistance += Time.deltaTime * 10;
			StartCoroutine ("Scanning");
			if (!go) {
				ScanDistance += Time.deltaTime * 10;
			} else {
				ScanDistance -= Time.deltaTime * 10;
			}



			foreach (Scannable s in _scannables)
			{
				if (Vector3.Distance(ScannerOrigin.position, s.transform.position) <= ScanDistance)
					s.Ping();
			}
		}

		if (Input.GetKeyDown(KeyCode.Space) && !canUse)
		{
			canUse = true;
			_scanning = true;
			ScanDistance = 0;
			StartCoroutine ("Stopscan");
		}
	}
	// End Demo Code

	void OnEnable()
	{
		_camera = GetComponent<Camera>();
		_camera.depthTextureMode = DepthTextureMode.Depth;
	}

	[ImageEffectOpaque]
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		EffectMaterial.SetVector("_WorldSpaceScannerPos", ScannerOrigin.position);
		EffectMaterial.SetFloat("_ScanDistance", ScanDistance);
		RaycastCornerBlit(src, dst, EffectMaterial);
	}

	void RaycastCornerBlit(RenderTexture source, RenderTexture dest, Material mat)
	{
		// Compute Frustum Corners
		float camFar = _camera.farClipPlane;
		float camFov = _camera.fieldOfView;
		float camAspect = _camera.aspect;

		float fovWHalf = camFov * 0.5f;

		Vector3 toRight = _camera.transform.right * Mathf.Tan(fovWHalf * Mathf.Deg2Rad) * camAspect;
		Vector3 toTop = _camera.transform.up * Mathf.Tan(fovWHalf * Mathf.Deg2Rad);

		Vector3 topLeft = (_camera.transform.forward - toRight + toTop);
		float camScale = topLeft.magnitude * camFar;

		topLeft.Normalize();
		topLeft *= camScale;

		Vector3 topRight = (_camera.transform.forward + toRight + toTop);
		topRight.Normalize();
		topRight *= camScale;

		Vector3 bottomRight = (_camera.transform.forward + toRight - toTop);
		bottomRight.Normalize();
		bottomRight *= camScale;

		Vector3 bottomLeft = (_camera.transform.forward - toRight - toTop);
		bottomLeft.Normalize();
		bottomLeft *= camScale;

		// Custom Blit, encoding Frustum Corners as additional Texture Coordinates
		RenderTexture.active = dest;

		mat.SetTexture("_MainTex", source);

		GL.PushMatrix();
		GL.LoadOrtho();

		mat.SetPass(0);

		GL.Begin(GL.QUADS);

		GL.MultiTexCoord2(0, 0.0f, 0.0f);
		GL.MultiTexCoord(1, bottomLeft);
		GL.Vertex3(0.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 0.0f);
		GL.MultiTexCoord(1, bottomRight);
		GL.Vertex3(1.0f, 0.0f, 0.0f);

		GL.MultiTexCoord2(0, 1.0f, 1.0f);
		GL.MultiTexCoord(1, topRight);
		GL.Vertex3(1.0f, 1.0f, 0.0f);

		GL.MultiTexCoord2(0, 0.0f, 1.0f);
		GL.MultiTexCoord(1, topLeft);
		GL.Vertex3(0.0f, 1.0f, 0.0f);

		GL.End();
		GL.PopMatrix();
	}

	IEnumerator Stopscan(){
		yield return new WaitForSeconds (secAutoScan);
		_scanning = false;
		ScanDistance = 0;
		canUse = false;
	}

	IEnumerator Scanning () {
		yield return new WaitForSeconds (secAutoScan/2);
		go = true;
		yield return new WaitForSeconds (secAutoScan/2);
		go = false;
	}
}
