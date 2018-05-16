using Assets.Scripts.BackEnd;
using Assets.Scripts.BackEnd.Programs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DrawingTests
{
    [Test]
    public void DrawingACardMovesACardFromStackToHand()
    {
        var blank = new BlankProgram();
        var runner = new Runner(new List<Program>() { blank }, 1);
        runner.StartBattle();

        runner.Draw();

        Assert.IsTrue(runner.Hand.Contains(blank));
        Assert.AreEqual(0, runner.Stack.Count());
    }

    [Test]
    public void Drawing2CardsMoves2CardsFromStackToHand()
    {
        var blank = new BlankProgram();
        var blank2 = new BlankProgram();
        var runner = new Runner(new List<Program>() { blank, blank2 }, 1);
        runner.StartBattle();

        runner.Draw(2);

        Assert.IsTrue(runner.Hand.Contains(blank) && runner.Hand.Contains(blank2));
        Assert.AreEqual(0, runner.Stack.Count());
    }

    [Test]
    public void DrawingACardWhenTheStackIsEmptyMovesTheHeapToTheStackThenDraws()
    {
        var blank = new BlankProgram();
        var runner = new Runner(new List<Program>() { blank }, 1);
        runner.StartBattle();
        runner.Draw();
        runner.PlayFromHand(blank);

        runner.Draw();

        Assert.IsTrue(runner.Hand.Contains(blank));
        Assert.AreEqual(0, runner.Stack.Count());
        Assert.AreEqual(0, runner.Heap.Count());
    }

    [Test]
    public void WhenMovingTheHeapToTheStackByDrawingItIsShuffled()
    {
        var success = false;
        for (var attempt = 1; attempt <= 10; attempt++)
        {
            var blanks = new Program[] { new BlankProgram(), new BlankProgram(), new BlankProgram(), new BlankProgram(), new BlankProgram() };
            var runner = new Runner(blanks.ToList(), 1);
            runner.StartBattle();
            runner.Draw(5);
            for (var i = 0; i < 5; i++)
                runner.PlayFromHand(blanks[i]);

            runner.Draw();

            if (!runner.Hand.Contains(blanks[0]))
            {
                success = true;
                break;
            }
        }
        Assert.IsTrue(success);
    }

    [Test]
    public void DrawingACardWhenStackAndHeapAreEmptyWillDoNothing()
    {
        var blank = new BlankProgram();
        var runner = new Runner(new List<Program>() { blank }, 1);
        runner.StartBattle();
        runner.Draw();

        runner.Draw();

        Assert.AreEqual(
            1, runner.Hand.Count());
        Assert.AreEqual(0, runner.Stack.Count());
        Assert.AreEqual(0, runner.Heap.Count());
    }
}
