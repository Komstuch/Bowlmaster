using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall) {
            rolls.Add(pinFall);
            ball.Reset();

            ActionMaster.Action nextAction = ActionMaster.NextAction(rolls);
            pinSetter.TriggerAnimator(nextAction);

        try{
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch {
            Debug.LogWarning("Something went wrong in Fill Rolls method");
        }
    }
}
