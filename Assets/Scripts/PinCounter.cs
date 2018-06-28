using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    private GameManager gameManager;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;
    private bool ballOutOfPlay = false;

    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	

	void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Ball>())
        {
            ballOutOfPlay = true;
        }
    }

    void UpdateStandingCountAndSettle()
    {
        if (lastStandingCount != CountStanding())
        {
            lastStandingCount = CountStanding();
            lastChangeTime = Time.time;
            return;
        }

        float settleTime = 3f; // How long to consider pins settled

        if (Time.time - lastChangeTime >= settleTime)
        { // If last change was 3s ago
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1; //Pins have settled and ball not back in box
        ballOutOfPlay = false;
        standingDisplay.color = Color.green; // Update diplay color to green

    }

    int CountStanding()
    {

        int standingPins = 0;
        Pin[] pins = FindObjectsOfType<Pin>();

        foreach (Pin currentPin in pins)
        {
            if (currentPin.IsStanding())
            {
                standingPins++;
            }
        }
        return standingPins;
    }
}
