using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public GameObject pinSet;

    private Animator animator;
    private PinCounter pinCounter;
    private Ball ball;
    private BallSignal ballSignal;

    private void Start(){
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        ball = GameObject.FindObjectOfType<Ball>();
        ballSignal = GameObject.FindObjectOfType<BallSignal>();
    }

    void Update(){
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
        Instantiate(pinSet, new Vector3(0, 41, 0), Quaternion.identity);
    }

    public void TriggerAnimator(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            pinCounter.Reset();
            animator.SetTrigger("resetTrigger");
        }
        else if (action == ActionMaster.Action.EndGame)
        {
           new WaitForSeconds(3);
        }
    }

    public void EnableBallLaunch() { //Last animation triggers Ball inPlay
        ball.inPlay = false;
        ballSignal.SignalGreen();
    }
}
