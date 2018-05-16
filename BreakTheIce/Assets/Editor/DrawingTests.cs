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
        var programs = CreatePrograms(1);
        var runner = SetupRunner(programs);

        runner.Draw();

        Assert.IsTrue(runner.Hand.Contains(programs[0]));
        Assert.AreEqual(0, runner.Stack.Count());
    }
    
    [Test]
    public void Drawing2CardsMoves2CardsFromStackToHand()
    {
        var programs = CreatePrograms(2);
        var runner = SetupRunner(programs);

        runner.Draw(2);

        CollectionAssert.AreEquivalent(new List<Program> { programs[0], programs[1] }, runner.Hand);
        Assert.AreEqual(0, runner.Stack.Count());
    }

    [Test]
    public void DrawingACardWhenTheStackIsEmptyMovesTheHeapToTheStackThenDraws()
    {
        var programs = CreatePrograms(1);
        var runner = SetupRunner(programs);
        runner.Draw();
        runner.PlayFromHand(programs[0]);

        runner.Draw();

        Assert.IsTrue(runner.Hand.Contains(programs[0]));
        Assert.AreEqual(0, runner.Stack.Count());
        Assert.AreEqual(0, runner.Heap.Count());
    }

    [Test]
    public void WhenMovingTheHeapToTheStackByDrawingItIsShuffled()
    {
        var programs = CreatePrograms(4);
        var runner = new Runner(new FakeRandom(new List<int>[] { new List<int> { 0, 1, 2, 3 }, new List<int> { 2, 1, 0, 3 } }),
            programs, 1);
        runner.StartBattle();

        runner.Draw(4);
        for (var i = 0; i < 4; i++)
            runner.PlayFromHand(programs[i]);

        runner.Draw();

        Assert.IsTrue(runner.Hand.Contains(programs[2]));
    }

    [Test]
    public void DrawingACardWhenStackAndHeapAreEmptyWillDoNothing()
    {
        var runner = SetupRunner(new List<Program>());

        runner.Draw();

        Assert.AreEqual(0, runner.Hand.Count());
        Assert.AreEqual(0, runner.Stack.Count());
        Assert.AreEqual(0, runner.Heap.Count());
    }

    private List<Program> CreatePrograms(int amount)
    {
        var programs = new List<Program>();
        for (var i = 0; i < amount; i++)
            programs.Add(new BlankProgram(i.ToString()));
        return programs;
    }

    private static Runner SetupRunner(List<Program> programs)
    {
        var runner = new Runner(new Rng(new Random()), programs, 1);
        runner.StartBattle();
        return runner;
    }
}
