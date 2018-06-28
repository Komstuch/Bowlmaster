using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public GameObject pinSet;

    private ActionMaster actionMaster;
    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;
    private int lastSettledCount = 10;
    private int currentBowlScore = 0;
    private Animator animator;

    private void Start(){
        ball = GameObject.FindObjectOfType<Ball>();
        actionMaster = new ActionMaster();
        animator = GetComponent<Animator>();
    }

    void Update(){
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox){
            UpdateStandingCountAndSettle();
        }
    }

    public void RaisePins() {
        foreach (Pin currentPin in GameObject.FindObjectsOfType<Pin>()){
            currentPin.RaiseIfStanding();
        }
    }

    public void LowerPins() {
        foreach (Pin currentPin in GameObject.FindObjectsOfType<Pin>()) {
            currentPin.LowerIfStanding();
        }
    }

    public void RenewPins(){
        Debug.Log("Renewing Pins");
        Instantiate(pinSet, new Vector3(0, 41, 0), Quaternion.identity);
    }

    void UpdateStandingCountAndSettle()
    {
        if(lastStandingCount != CountStanding()){
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
        int standing = CountStanding();
        currentBowlScore = lastSettledCount - standing;
        lastSettledCount = standing;

        TriggerAnimator();

        ball.Reset();
        lastStandingCount = -1; //Pins have settled and ball not back in box
        ballEnteredBox = false;
        standingDisplay.color = Color.green; // Update diplay color to green
    }

    void TriggerAnimator() {
        ActionMaster.Action action = actionMaster.Bowl(currentBowlScore);
        print("Pin fall: " + currentBowlScore + " Action: " + action);
        if(action == ActionMaster.Action.Tidy){
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            lastSettledCount = 10;
            animator.SetTrigger("resetTrigger");
        } else if (action == ActionMaster.Action.Reset) {
            lastSettledCount = 10;
            animator.SetTrigger("resetTrigger");
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle End of the Game");
        }
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Ball>()) // If we hit the ball change the color of the display to red
        {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }
}
