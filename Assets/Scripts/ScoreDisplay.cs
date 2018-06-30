using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{ 
    public Text[] rollText;
    public Text[] frameText;

    public void FillRolls(List<int> rolls) {
        string ScoresString = FormatRolls(rolls);
        for (int i = 0; i < ScoresString.Length; i++) {
            rollText[i].text = ScoresString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames) {
        for (int i = 0; i < frames.Count; i++) {
            frameText[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls) {
        string output = "";


        return output;
    }
}
