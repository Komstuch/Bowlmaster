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
        if (!ball.inPlay) {
            startTime = Time.timeSinceLevelLoad;

            startMousePosition = Input.mousePosition;
        }
    }

    public void DrageEnd (){
        if (!ball.inPlay){
            dragDuration = Time.timeSinceLevelLoad - startTime;
            dragDirection = Input.mousePosition - startMousePosition;

            launchVector = new Vector3(dragDirection.x, dragDirection.z, dragDirection.y); // Switch coordinates so the ball moves in plane paralell to the swipe direction
            launchVector = launchVector / dragDuration; //Scale the launch direction with drag speed

            launchVector.x = Mathf.Clamp(launchVector.x, -30f, 30f); // Constrain velocity so ball won't fly off in space
            launchVector.z = Mathf.Clamp(launchVector.z, 50f, 700f);
            ball.Launch(launchVector);
        }
    }

    public void MoveStart(float xNudge) {
        if ( ! ball.inPlay) {

            if ((ball.transform.position.x - xNudge) < -50 || (ball.transform.position.x + xNudge) > 50)
            {
                return;
            }

            ball.transform.Translate(new Vector3(xNudge, 0, 0));
        }
    }
}   

