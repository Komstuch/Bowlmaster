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

}
