using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 startPosition;

    public Vector3 launchVelocity;
    public bool inPlay = false;

	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false; // Turn off Ball gravity at start
        startPosition = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true; //Turn on Ball velocity at launch 
        rigidBody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Reset() {
        inPlay = false;
        transform.position = startPosition;
        rigidBody.useGravity = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }
}
