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
        var runner = new Runner(new Rng(new Random()), new List<Program>() { blank }, 1);
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
        var runner = new Runner(new Rng(new Random()), new List<Program>() { blank, blank2 }, 1);
        runner.StartBattle();

        runner.Draw(2);

        Assert.IsTrue(runner.Hand.Contains(blank) && runner.Hand.Contains(blank2));
        Assert.AreEqual(0, runner.Stack.Count());
    }

    [Test]
    public void DrawingACardWhenTheStackIsEmptyMovesTheHeapToTheStackThenDraws()
    {
        var blank = new BlankProgram();
        var runner = new Runner(new Rng(new Random()), new List<Program>() { blank }, 1);
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
        var blanks = new Program[] { new BlankProgram("0"), new BlankProgram("1"), new BlankProgram("2"), new BlankProgram("3"), new BlankProgram("4") };
        var runner = new Runner(new FakeRandom(new List<int>[] { new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 2, 1, 0, 3, 4 } }), blanks.ToList(), 1);
        runner.StartBattle();
        runner.Draw(5);
        for (var i = 0; i < 5; i++)
            runner.PlayFromHand(blanks[i]);

        runner.Draw();

        Assert.IsTrue(runner.Hand.Contains(blanks[2]));
    }

    [Test]
    public void DrawingACardWhenStackAndHeapAreEmptyWillDoNothing()
    {
        var blank = new BlankProgram();
        var runner = new Runner(new Rng(new Random()), new List<Program>() { blank }, 1);
        runner.StartBattle();
        runner.Draw();

        runner.Draw();

        Assert.AreEqual(
            1, runner.Hand.Count());
        Assert.AreEqual(0, runner.Stack.Count());
        Assert.AreEqual(0, runner.Heap.Count());
    }
}
