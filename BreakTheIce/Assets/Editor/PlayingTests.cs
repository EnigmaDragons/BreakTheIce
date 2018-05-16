using Assets.Scripts.BackEnd;
using Assets.Scripts.BackEnd.Programs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayingTests
{
    [Test]
    public void PlayingFromHandDiscardsTheCardAfterwords()
    {
        var program = new BlankProgram();
        var runner = SetupRunnerWith(program);

        runner.PlayFromHand(program);

        Assert.AreEqual(0, runner.Hand.Count());
        Assert.IsTrue(runner.Heap.Contains(program));
    }

    [Test]
    public void PlayingFromHandSpendsTime()
    {
        var program = new ExpensiveBlankProgram();
        Runner runner = SetupRunnerWith(program);
        var time = runner.Time;

        runner.PlayFromHand(program);

        Assert.AreEqual(time - 2, runner.Time);
    }

    [Test]
    public void PlayingFromHandResolvesTheProgram()
    {
        var program = new GainMaxHpProgram();
        Runner runner = SetupRunnerWith(program);

        runner.PlayFromHand(program);

        Assert.Greater(runner.MaxHP, 1);
    }

    private static Runner SetupRunnerWith(Program program)
    {
        var runner = new Runner(new Rng(new Random()), new List<Program>() { program }, 1);
        runner.StartBattle();
        runner.Draw();
        return runner;
    }
}
