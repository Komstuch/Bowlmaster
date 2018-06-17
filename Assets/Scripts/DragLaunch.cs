using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;

    float startTime, dragDuration;
    Vector3 startMousePosition, dragDirection, launchVector;


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
}

