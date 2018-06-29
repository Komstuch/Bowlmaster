﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ScoreMasterTest{

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl23()
    {
        int[] rolls = { 2, 3 };
        int[] frames = { 5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T02Bowl234()
    {
        int[] rolls = { 2, 3, 4 };
        int[] frames = { 5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T03Bowl2345()
    {
        int[] rolls = { 2, 3, 4, 5 };
        int[] frames = { 5, 9 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T04Bowl23456()
    {
        int[] rolls = { 2, 3, 4, 5, 6 };
        int[] frames = { 5, 9 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T05Bowl234561()
    {
        int[] rolls = { 2, 3, 4, 5, 6, 1 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T06Bowl2345612()
    {
        int[] rolls = { 2, 3, 4, 5, 6, 1, 2 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T07BowlX1()
    {
        int[] rolls = { 10, 1 };
        int[] frames = { };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T08Bowl19()
    {
        int[] rolls = { 1, 9 };
        int[] frames = { };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T09Bowl123455()
    {
        int[] rolls = { 1, 2, 3, 4, 5, 5 };
        int[] frames = { 3, 7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T10SpareBonus()
    {
        int[] rolls = { 1, 2, 3, 5, 5, 5, 3, 3 };
        int[] frames = { 3, 8, 13, 6 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T11SpareBonus2()
    {
        int[] rolls = { 1, 2, 3, 5, 5, 5, 3, 3, 7, 1, 9, 1, 6 };
        int[] frames = { 3, 8, 13, 6, 8, 16 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T12StrikeBonus()
    {
        int[] rolls = { 10, 3, 4 };
        int[] frames = { 17, 7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T13StrikeBonus3()
    {
        int[] rolls = { 1, 2, 3, 4, 5, 4, 3, 2, 10, 1, 3, 3, 4 };
        int[] frames = { 3, 7, 9, 5, 14, 4, 7 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T14MultiStrikes()
    {
        int[] rolls = { 10, 10, 2, 3 };
        int[] frames = { 22, 15, 5 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T15MultiStrikes3()
    {
        int[] rolls = { 10, 10, 2, 3, 10, 5, 3 };
        int[] frames = { 22, 15, 5, 18, 8 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T16TestGutterGame()
    {
        int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] totalS = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T17TestAllOnes()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }


    [Test]
    public void T18TestAllStrikes()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        int[] totalS = { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T19TestImmediateStrikeBonus()
    {
        int[] rolls = { 5, 5, 3 };
        int[] frames = { 13 };
        Assert.AreEqual(frames.ToList(), ScoreMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T20SpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 7 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 35 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }

    [Test]
    public void T21StrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 2, 3 };
        int[] totalS = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 33 };
        Assert.AreEqual(totalS.ToList(), ScoreMaster.ScoreCumulative(rolls.ToList()));
    }


}
