using UnityEngine;
using System.Collections;

public class RunInBackGround : MonoBehaviour {

    void Start ()
    {
        Application.runInBackground = true;
    }
}
