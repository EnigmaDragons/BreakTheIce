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
        var blank = new BlankProgram();
        var runner = new Runner(new List<Program>() { blank }, 1);
        runner.StartBattle();
        runner.Draw();

        runner.PlayFromHand(blank);

        Assert.AreEqual(0, runner.Hand.Count());
        Assert.IsTrue(runner.Heap.Contains(blank));
    }
}
