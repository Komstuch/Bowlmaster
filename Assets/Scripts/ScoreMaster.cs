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

        int buffer1 = 0;
        int buffer1Count = 0;
        int buffer2 = 0;
        int buffer2Count = 0;
        int buffer3 = 0;
        int rollsCount = 0;
        int frameScore = 0;
        int StrikeCounter = 0; 
        int previousRoll = 0;

        foreach (int roll in rolls)
        {
            rollsCount++;

            if (roll == 10)
            {
                if(buffer1 != 0)
                {
                    buffer1 += roll;
                    buffer2 += roll;
                    buffer2Count = 2;
                    buffer1Count--;
                    rollsCount++;
                }
                else
                {
                    rollsCount++;
                    buffer1 = roll;
                    buffer1Count = 2;
                }
            } else {
                if (buffer1Count>0) {
                    buffer1 += roll;
                    buffer1Count--;
                    if(buffer1Count == 0)
                    {
                        frameList.Add(buffer1);
                        buffer1 = 0;
                    }
                }
                if (buffer2Count > 0)
                {
                    buffer2 += roll;
                    buffer2Count--;
                    if (buffer2Count == 0)
                    {
                        frameList.Add(buffer2);
                        buffer2 = 0;
                    }
                }
                frameScore += roll;
                if (rollsCount % 2 == 0)
                {
                    if (frameScore == 10)
                    {
                        buffer3 = frameScore;
                        frameScore = 0;
                    }
                    else
                    {
                        frameList.Add(frameScore);
                        frameScore = 0;
                    }
                }
                else if (buffer3 != 0)
                {
                    frameList.Add(roll + buffer3);
                    buffer3 = 0;
                }
            }
        }
        foreach(int frame in frameList)
        {
            Debug.Log("Frame: " + frame);
        }
        return frameList;
    }



}


////Returns list of individual frame scores
//public static List<int> ScoreFrames(List<int> rolls)
//{
//    List<int> frameList = new List<int>();

//    //int frameNumber = 1;
//    int rollsCount = 0;
//    int frameScore = 0;
//    int StrikeBonus = 0;
//    int StrikeCounter = 0;
//    int SpareBonus = 0;

//    foreach (int roll in rolls)
//    {
//        rollsCount++;

//        if (roll == 10 && (rollsCount % 2) == 1)
//        {
//            StrikeBonus += roll;
//            StrikeCounter = 2;
//            rollsCount += 1;
//        }
//        else
//        {
//            frameScore += roll;
//            if (StrikeCounter > 0)
//            {
//                StrikeBonus += roll;
//                StrikeCounter--;
//                if (StrikeCounter == 0)
//                {
//                    frameList.Add(StrikeBonus);
//                }
//            }
//            if (rollsCount % 2 == 0)
//            {
//                if (frameScore == 10)
//                {
//                    SpareBonus = frameScore;
//                    frameScore = 0;
//                }
//                else
//                {
//                    frameList.Add(frameScore);
//                    frameScore = 0;
//                }
//            }
//            else if (SpareBonus != 0)
//            {
//                frameList.Add(roll + SpareBonus);
//                SpareBonus = 0;
//            }
//        }
//    }
//    return frameList;
//}


