using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>();
    private List<int> boxes = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;
    private SceneLoader sceneLoader;

    public static int finalScore;

	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
    }

    public void Bowl(int pinFall) {
        rolls.Add(pinFall);
        boxes.Add(pinFall);
        ball.Reset();

            ActionMaster.Action nextAction = ActionMaster.NextAction(boxes);

        if(nextAction == ActionMaster.Action.EndGame)
        {
            finalScore = ScoreMaster.ScoreCumulative(rolls)[9];
            new WaitForSeconds(3);
            sceneLoader.LoadNextScreen();
        }

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
