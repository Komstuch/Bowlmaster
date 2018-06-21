using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;

    bool ballEnteredBox = false;

    void Update(){
        standingDisplay.text = CountStanding().ToString();
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
