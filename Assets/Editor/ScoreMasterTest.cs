using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ScoreMasterTest{

    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl23() {
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

}
