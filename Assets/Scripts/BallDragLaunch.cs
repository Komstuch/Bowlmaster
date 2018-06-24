using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private float startTime, dragDuration;
    private Vector3 startMousePosition, dragDirection, launchVector;


    void Start () {
        ball = GetComponent<Ball>();
	}

    public void DragStart() { // Capture time and position of mouse click
       startTime = Time.timeSinceLevelLoad;

       startMousePosition = Input.mousePosition;
    }

    public void DrageEnd (){
        dragDuration = Time.timeSinceLevelLoad - startTime;
        dragDirection = Input.mousePosition - startMousePosition;

        launchVector = new Vector3(dragDirection.x, dragDirection.z, dragDirection.y); // Switch coordinates so the ball moves in plane paralell to the swipe direction
        launchVector = launchVector / dragDuration; //Scale the launch direction with drag speed

        ball.Launch(launchVector);
    }

    public void MoveStart(float xNudge) {
        if ( ! ball.inPlay) {
            ball.transform.Translate(new Vector3(xNudge, 0, 0));
        }
    }
}   

