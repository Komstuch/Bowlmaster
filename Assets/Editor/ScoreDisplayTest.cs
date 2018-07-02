using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ScoreDisplayTest
{
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl1()
    {
        int[] rolls = { 1 };
        string rollsString = "1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02Bowl1234()
    {
        int[] rolls = { 1, 2, 3, 4 };
        string rollsString = "1234";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03Bowl20TimesOne()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        string rollsString = "11111111111111111111";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04BowlSpare()
    {
        int[] rolls = { 1, 9 };
        string rollsString = "1/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05BowlSpare2()
    {
        int[] rolls = { 1, 9, 2, 4, 4, 6 };
        string rollsString = "1/244/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05BowlSpareInLastFrame()
    {
        int[] rolls = { 1, 9, 2, 4, 4, 6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 5 };
        string rollsString = "1/244/1111111111111/5";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T06BowlStrike()
    {
        int[] rolls = { 10 };
        string rollsString = "X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T07BowlStrikeOne()
    {
        int[] rolls = { 10, 1 };
        string rollsString = "X 1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T08BowlTwoStrikes()
    {
        int[] rolls = { 10, 10 };
        string rollsString = "X X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T09BowlTwoStrikesOne()
    {
        int[] rolls = { 10, 10, 1 };
        string rollsString = "X X 1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T10BowlStrikeSpareOne()
    {
        int[] rolls = { 10, 1, 9, 1 };
        string rollsString = "X 1/1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T10BowlStrikeSpareSpareStrike()
    {
        int[] rolls = { 10, 1, 9, 1, 9, 10};
        string rollsString = "X 1/1/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
}
