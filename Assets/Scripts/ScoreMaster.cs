using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {



    //Returns a list of cumulative scores like a normal scorecard
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScore = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScore.Add(runningTotal);
        }
        return cumulativeScore;
    }

    //Returns list of individual frame scores
    public static List<int> ScoreFrames (List<int> rolls) {
        List<int> frameList = new List<int>();

        // Index i points to second bowl of frame
        for (int i = 1; i < rolls.Count; i += 2){  
            if (frameList.Count == 10) { break; }   //Leave game if we have compleated the last frame

            if ((rolls[i - 1] + rolls[i]) < 10)     //Normal Open Frame
            { 
                frameList.Add(rolls[i - 1] + rolls[i]);
            }

            if(rolls.Count - i <= 1) {break; }      // Insufficient Look Ahead

            if (rolls[i - 1] == 10)                 // Strike
            {
                i--;                                // Strike frame has just one bowl
                frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
            } else if ((rolls[i-1] + rolls[i]) == 10)      //Spare bonus calculation
            {
                frameList.Add(10 + rolls[i+1]);
            }
        }
        return frameList;
    }
}