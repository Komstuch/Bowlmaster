using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody rigidBody;
    private AudioSource audioSource;

    public Vector3 launchVelocity;

	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        Launch();
    }

    public void Launch()
    {
        rigidBody.velocity = launchVelocity;
        audioSource.Play();
    }
}
