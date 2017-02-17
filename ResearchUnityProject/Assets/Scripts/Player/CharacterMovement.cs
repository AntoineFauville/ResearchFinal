using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour {

	public int state;
	public int previousState;

	private const int 	IDLE = 0,
						WALK = 1,
						SIT = 2;

	public float moveSpeed = 25.0f,
	moveTurnSpeed = 3.0f;

	float m_RunCycleLegOffset = 0.2f,
	m_StationaryTurnSpeed = 18;

	GameObject MainCamera;
	private Vector3 VectorCamera;

	private Vector3 velocity;
	public Rigidbody rigidbody;
	public CapsuleCollider collider;

	Animator animator;

	float m_TurnAmount,
		m_ForwardAmount,
		translation,
		rotation,
	 	MovingRotation,
		angleY;

	void Start()
	{
		state = IDLE;
		animator = GetComponent<Animator>();
		MainCamera = GameObject.Find ("Main Camera Main");
	}

	void FixedUpdate() 
	{
		if(Input.GetAxis ("Vertical") > 0.2f || Input.GetAxis ("Vertical") < -0.2f){
			state = WALK;
		} else if(Input.GetAxis ("Vertical") == 0){
			state = IDLE;
		}

		//if we need to be in the different state next
		/*if (previousState != state) {
			switch(state){
			case IDLE:
				RectifyCamera ();
				rotation = Input.GetAxis ("Horizontal") * moveTurnSpeed;
				m_TurnAmount = Mathf.Atan2 (rotation, rotation);
				transform.Rotate(0, rotation, 0);
				break;

			case SIT:
				break;

			default:
				break;
			}
		}
		previousState = state;*/

		//if we need to stay in the different state
		switch(state){

		case IDLE:
			RectifyCamera ();
			rotation = Input.GetAxis ("Horizontal") * moveTurnSpeed / 5;
			m_TurnAmount = Mathf.Atan2 (rotation, rotation);
			transform.Rotate(0, rotation, 0);
			break;

		case WALK:
			if (Input.GetAxis ("Vertical") > 0) {
				Move ();
			} else if (Input.GetAxis ("Vertical") < 0) {
				MoveBack ();
			}
			break;

		case SIT:
			break;

		default:
			break;
		}
			

		float v = Input.GetAxis("Vertical");

		translation = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;

		if (Input.GetAxis ("Vertical") == 0) { // not moving
			


		} else if (Input.GetAxis ("Vertical") < 0) { // going back
			m_TurnAmount = Mathf.Atan2 (rotation, rotation);
			rotation = -Input.GetAxis ("Horizontal") * moveTurnSpeed;

		} else { // straight
			rotation = Input.GetAxis ("Horizontal") * moveTurnSpeed;
			m_TurnAmount = Mathf.Atan2 (0, 0);
		}

		animator.SetFloat("Forward", m_ForwardAmount*50, 0.1f, Time.deltaTime);
		animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);

		animator.SetFloat("Forward",v);
		velocity = rigidbody.velocity;

		m_ForwardAmount = translation;

		transform.Rotate(0, rotation, 0);
	}

	void Move(){
		transform.Translate(0, 0, translation);
	}

	void MoveBack (){
		transform.Translate(0, 0, translation/3);
	}


	void RectifyCamera(){
		//si la camera a un angle different et qu'on appuie sur vertical 

		float actualXCam = MainCamera.transform.rotation.eulerAngles.x;
		float actualYCam = MainCamera.transform.rotation.eulerAngles.y;
		float actualZCam = MainCamera.transform.rotation.eulerAngles.z;

		float actualXPla = transform.rotation.eulerAngles.x;
		float actualYPla = transform.rotation.eulerAngles.y;
		float actualZPla = transform.rotation.eulerAngles.z;

		MainCamera.transform.rotation = Quaternion.Euler (actualXCam,actualYCam,actualZCam);
		transform.rotation = Quaternion.Euler (actualXPla,actualYPla,actualZPla);

		if(Input.GetAxis ("Vertical") > 0 && MainCamera.transform.rotation.eulerAngles.y != transform.rotation.eulerAngles.y)
		{
			transform.rotation = Quaternion.Euler (actualXPla,actualYCam,actualZPla);
		} 
	}
}





/*if (Input.GetAxis ("Vertical") > 0) {
translation = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
m_TurnAmount = Mathf.Atan2 (0, 0);
MovingRotation = moveTurnSpeed * Input.GetAxis ("Vertical");
m_TurnAmount = Mathf.Atan2 (0, 0);
translation = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
MovingRotation = moveTurnSpeed * Input.GetAxis ("Vertical");
} else if (Input.GetAxis ("Vertical") < 0){
	m_TurnAmount = Mathf.Atan2 (0, 0);
	translation = (Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime)/2;
	MovingRotation = moveTurnSpeed * Input.GetAxis ("Vertical");
} else if (Input.GetAxis ("Vertical") == 0){
	MovingRotation = moveTurnSpeed;
	m_TurnAmount = Mathf.Atan2(rotation,rotation);
}
//angleY = (axeDeDirection.y / (Mathf.Sqrt(1-axeDeDirection.w * axeDeDirection.w)));
//print (angleY);

//angleY = 2 * Mathf.Acos (axeDeDirection.y);

//print("sinY " + Mathf.Asin (axeDeDirectionJoueur.y) * 100);
//print("cosY " + Mathf.Acos (axeDeDirectionJoueur.y) * 100);
//print ( transform.rotation.eulerAngles.y);


//print(MainCamera.transform.rotation);
//print(transform.rotation);*/