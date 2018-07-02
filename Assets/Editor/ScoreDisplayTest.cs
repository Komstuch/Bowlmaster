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

    [Test]
    public void T11BowlTenSparesAnd5()
    {
        int[] rolls = {1,9, 1,9, 1,9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 5};
        string rollsString = "1/1/1/1/1/1/1/1/1/1/5";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T12BowlAllStrikes()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10};
        string rollsString = "X X X X X X X X X XXX";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T13LastFrameSpareAndStrike()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 2, 8, 10 };
        string rollsString = "X X X X X X X X X 2/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
    [Test]
    public void T14LastFrameStrikeAndSpare()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 8, 2 };
        string rollsString = "X X X X X X X X X X8/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T15BowlZero()
    {
        int[] rolls = { 0 };
        string rollsString = "-";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T16BowlZeros()
    {
        int[] rolls = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0 };
        string rollsString = "--------------------";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T17BowlZeroX()
    {
        int[] rolls = { 0, 10 };
        string rollsString = "-/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("Verification")]
    [Test]
    public void TG01GoldenCopyC1of3()
    {
        int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
        string rollsString = "72X X X X 7/X X 9/XX9";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("Verification")]
    [Test]
    public void TG02GoldenCopyC2of3()
    {
        int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
        string rollsString = "X X X X 9-X X X X X9/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB3of3()
    {
        int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
        string rollsString = "X X 9-X 7/X 8163629/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

}
