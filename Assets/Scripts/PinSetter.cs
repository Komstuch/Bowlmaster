using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

   
    public GameObject pinSet;

    private Animator animator;
    private ActionMaster actionMaster;
    private PinCounter pinCounter; 

    private void Start(){
       // ball = GameObject.FindObjectOfType<Ball>();
       // actionMaster = new ActionMaster();
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
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
        // ActionMaster.Action action = actionMaster.Bowl(currentBowlScore);
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
            throw new UnityException("Don't know how to handle End of the Game");
        }
    }
}
