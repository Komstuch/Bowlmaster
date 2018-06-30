using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall) {
            bowls.Add(pinFall);
            ball.Reset();

            ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
            pinSetter.TriggerAnimator(nextAction);

        try{
            scoreDisplay.FillRollCard(bowls);
        }
        catch {
            Debug.LogWarning("Something went wrong in Fill Roll Card method");
        }
    }
}
