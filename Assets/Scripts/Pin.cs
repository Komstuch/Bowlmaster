using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 5f;

	void Start () {

	}
	
	void Update () {
        print(name + " " + IsStanding());
    }

    public bool IsStanding(){
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX <= standingThreshold && tiltInZ <= standingThreshold) {
            return true;
        }
        return false;
    }
}
