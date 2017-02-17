using UnityEngine;
using System.Collections;

public class LookAtSimple : MonoBehaviour {

    public Transform myTransForm;
    public Transform Player;
    public float rotationSpeedOfEnnemi = 5;
    
    void Update () {
        lookAtPlayer();
    }

    void lookAtPlayer() {
        myTransForm.rotation = Quaternion.Slerp(myTransForm.rotation, Quaternion.LookRotation(Player.position - myTransForm.position), rotationSpeedOfEnnemi * Time.deltaTime);
    }
}
