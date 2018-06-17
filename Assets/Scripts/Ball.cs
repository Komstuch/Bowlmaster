using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody rigidBody;
    private AudioSource audioSource;

    public Vector3 launchVelocity;
    public bool inPlay = false;

	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false; // Turn off Ball gravity at start
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true; //Turn on Ball velocity at launch 
        rigidBody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
