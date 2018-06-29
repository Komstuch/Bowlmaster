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

        //int frameNumber = 1;
        int rollsCount = 0;
        int frameScore = 0;
        int StrikeBonus = 0;
        int StrikeCounter = 0; 
        int SpareBonus = 0;

        foreach (int roll in rolls)
        {
            rollsCount++;

            if (roll == 10 && (rollsCount % 2) == 1) {
                StrikeBonus += roll;
                StrikeCounter = 2;
                rollsCount += 1;
            } else {
                frameScore += roll;
                if(StrikeCounter > 0)
                {
                    StrikeBonus += roll;
                    StrikeCounter--;
                    if (StrikeCounter == 0) {
                        frameList.Add(StrikeBonus);
                    }
                }
                if (rollsCount % 2 == 0) {
                    if (frameScore == 10) {
                        SpareBonus = frameScore;
                        frameScore = 0;
                    }
                    else {
                        frameList.Add(frameScore);
                        frameScore = 0;
                    }
                } else if (SpareBonus !=0) {
                    frameList.Add(roll + SpareBonus);
                    SpareBonus = 0;
                }
            }
        }
        return frameList;
    }



}


//public static List<int> ScoreFrames(List<int> rolls)
//{
//    List<int> frameList = new List<int>();

//    //int frameNumber = 1;
//    int rollsCount = 0;
//    int frameScore = 0;

//    foreach (int roll in rolls)
//    {
//        rollsCount++;
//        frameScore += roll;
//        if (rollsCount % 2 == 0)
//        {
//            frameList.Add(frameScore);
//            frameScore = 0;
//        }


//    }
//    return frameList;
//}