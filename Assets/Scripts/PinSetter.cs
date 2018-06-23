using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 40f;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

    private void Start(){
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void Update(){
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox){
            CheckStanding();
        }
    }

    public void RaisePins() {       // Raise standing pins only by distanceToRaise 
        Debug.Log("Raising Pins");
        foreach (Pin currentPin in GameObject.FindObjectsOfType<Pin>())
        {
            if (currentPin.IsStanding())
            {
                currentPin.transform.Translate(new Vector3(0, distanceToRaise, 0));
            }
        }
    }

    public void LowerPins()
    {
        // Lower standing pins only by distanceToRaise 
        Debug.Log("Lowering Pins");
    }

    public void RenewPins()
    {
        Debug.Log("Renewing Pins");
    }

    void CheckStanding()
    {
        if(lastStandingCount != CountStanding())
        {
            lastStandingCount = CountStanding();
            lastChangeTime = Time.time;
            return;
        }

        float settleTime = 3f; // How long to consider pins settled
    
        if (Time.time - lastChangeTime >= settleTime){ // If last change was 3s ago
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled() {
        ball.Reset();
        lastStandingCount = -1; //Pins have settled and ball not back in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green; // Update diplay color to green
    }

    int CountStanding() {

        int standingPins = 0;
        Pin[] pins = FindObjectsOfType<Pin>();

        foreach (Pin currentPin in pins) {
            if (currentPin.IsStanding()) {
                standingPins++;
            }
        }
        return standingPins;
    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;

        if (thingLeft.GetComponent<Pin>()){
            Destroy(thingLeft);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Ball>()) // If we hit the ball change the color of the display to red
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }
}
