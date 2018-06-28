using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 5f;
    public float distToRaise = 40f;


    public void RaiseIfStanding()
    {       // Raise standing pins only by distToRaise 
        if (IsStanding()){
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void LowerIfStanding(){
        // Lower standing pins only by distanceToRaise 
        if (IsStanding()){
            transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public bool IsStanding(){
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX <= standingThreshold && tiltInZ <= standingThreshold) {
            return true;
        }
        else {
            return false;
        }
    }
}
