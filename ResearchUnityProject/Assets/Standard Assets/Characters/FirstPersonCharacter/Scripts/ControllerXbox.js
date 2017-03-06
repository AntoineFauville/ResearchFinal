#pragma strict

private var rotateSpeed:float = 0.5;
var cameraPivot : Transform;
var rotationSpeed : Vector2 = Vector2( 100, 50 );   // Camera rotation speed for each axis
 
// Use this for initialization
function Awake () {
 
}
 
// Update is called once per frame
function Update () {
    // Get the input vector from kayboard or analog stick
    var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
       // Rotate around y - axis
       
    if (directionVector != Vector3.zero) {
        // Get the length of the directon vector and then normalize it
        // Dividing by the length is cheaper than normalizing when we already have the length anyway
        var directionLength = directionVector.magnitude;
        directionVector = directionVector / directionLength;
       
        // Make sure the length is no bigger than 1
        directionLength = Mathf.Min(1, directionLength);
       
        // Make the input vector more sensitive towards the extremes and less sensitive in the middle
        // This makes it easier to control slow speeds when using analog sticks
        directionLength = directionLength * directionLength;
       
        // Multiply the normalized direction vector by the modified length
        directionVector = directionVector * directionLength;
    }
   
    // Apply the direction to the CharacterMotor
//    motor.inputMoveDirection = transform.rotation * directionVector;
  //  motor.inputJump = Input.GetButton("Jump");
   
   
    // Rotate the camera
    var camRotation = Vector2.zero;
    camRotation = Vector2(Input.GetAxis ("HorizontalRight"),Input.GetAxis("VerticalRight"));
    camRotation.x *= rotationSpeed.x;
    camRotation.y *= rotationSpeed.y;
    camRotation *= Time.deltaTime;
       
    // Rotate the character around world-y using x-axis of joystick
    transform.Rotate( 0, camRotation.x, 0, Space.World );
    // Rotate only the camera with y-axis input
    cameraPivot.Rotate( -camRotation.y, 0, 0 );
}
