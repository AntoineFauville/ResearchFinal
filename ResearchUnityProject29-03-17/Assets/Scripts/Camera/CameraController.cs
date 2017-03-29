using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform cameraTarget;
	private float x = 0.0f;
	private float y = 0.0f;

	public int mouseXSpeedMod = 4; //vitesse en X mouvement camera
	public int mouseYSpeedMod = 2; //speed in Y of camera movement

	public float maxViewDistance = 25; //how far the cam can go
	public float minViewDistance = 10; //min distance
	public int zoomRate = 60;  //how fast the cam can zoom
	public int lerpRate = 10; //rate it get back to your reset camera
	public float distance = 3; //starting dist
	private float desiredDistance; //used for calculations
	private float correctedDistance; //used for calculations
	private float currentDistance;

	public float cameraTargetHeight = 1.0f; // depending on how tall my capsule is

	void Start () {
		Vector3 angles = transform.eulerAngles; //set variables x to angles.x
		x = angles.x;
		y = angles.y;
		//set distances
		currentDistance = distance;
		desiredDistance = distance;
		correctedDistance = distance;
	}

	void LateUpdate () 
	{
		/*if (Input.GetMouseButton (0)) 
		{ // 0 = left 1 = right
			x += Input.GetAxis ("Mouse X") * mouseXSpeedMod;
			y -= Input.GetAxis ("Mouse Y") * mouseYSpeedMod;
		} else if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) //if vertical or horizontal the code will execute
		{
			float targetRotationAngle = cameraTarget.eulerAngles.y;
			float cameraRotationAngle = transform.eulerAngles.y;
			x = Mathf.LerpAngle(cameraRotationAngle, targetRotationAngle, lerpRate * Time.deltaTime); //rotate the camera with euler calcul of moving
		}*/
		if (Input.GetMouseButton (1)) // getbuttondown?
		{ // 0 = left 1 = right
			x += Input.GetAxis ("Mouse X") * mouseXSpeedMod;
			y -= Input.GetAxis ("Mouse Y") * mouseYSpeedMod;
		} else if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) //if vertical or horizontal the code will execute
		{
			float targetRotationAngle = cameraTarget.eulerAngles.y;
			float cameraRotationAngle = transform.eulerAngles.y;
			x = Mathf.LerpAngle(cameraRotationAngle, targetRotationAngle, lerpRate * Time.deltaTime); //rotate the camera with euler calcul of moving
		}

		y = ClampAngle (y, -90, 90);

		Quaternion rotation = Quaternion.Euler (y, x, 0);

		desiredDistance += Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime *  zoomRate * Mathf.Abs (desiredDistance); // cam calcul of the distance
		desiredDistance = Mathf.Clamp (desiredDistance, minViewDistance, maxViewDistance);
		correctedDistance = desiredDistance;

		Vector3 position = cameraTarget.position - (rotation * Vector3.forward * desiredDistance);

		RaycastHit collisionHit;
		Vector3 cameraTargetPosition = new Vector3 (cameraTarget.position.x, cameraTarget.position.y + cameraTargetHeight, cameraTarget.position.z);

		bool isCorrected = false;
		if (Physics.Linecast (cameraTargetPosition, position, out collisionHit)) 
		{
			position = collisionHit.point;
			correctedDistance = Vector3.Distance(cameraTargetPosition, position);
			isCorrected = true;
		}

		//condition opperator
		//?:
		//condition ? first_expression : second_expression; //
		//(input > 0) ? isPositive : isNegative;*/

		currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * zoomRate) : correctedDistance;

		position = cameraTarget.position - (rotation * Vector3.forward * currentDistance + new Vector3 (0, -cameraTargetHeight, 0));

		transform.rotation = rotation;
		transform.position = position;
	}
	private static float ClampAngle(float angle,float min, float max){
		if (angle < -360) {
			angle +=360;
		}
		if (angle > 360) {
			angle -=360;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
