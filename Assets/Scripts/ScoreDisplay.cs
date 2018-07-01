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

        if (rolls[0] == 10)
        {
            output += "X";
        }
        else
        {
            output += rolls[0].ToString();
        }

 

        for (int i = 1; i < rolls.Count; i++){

            if (rolls[i] == 10)
            {
                output += "X";
            } else if (rolls[i-1] + rolls[i] == 10)
            {
                output += "/";
            }
            else
            {
                output += rolls[i].ToString();
            }


        }


        return output;
    }
}
