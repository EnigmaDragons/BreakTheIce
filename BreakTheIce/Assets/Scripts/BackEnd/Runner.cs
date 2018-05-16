using Assets.Scripts.BackEnd.Programs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.BackEnd
{
    public class Runner
    {
        public int Money { get; private set; }
        public int MaxHP { get; private set; }
        public int Hp { get; private set; }
        public int BrainDamage { get; private set; }
        public int Tags { get; private set; }
        public int Time { get; private set; }

        public List<Program> InstalledPrograms { get; private set; }
        public List<Program> Stack { get; private set; } = new List<Program>();
        public List<Program> Hand { get; private set; } = new List<Program>();
        public List<Program> Heap { get; private set; } = new List<Program>();

        public Runner(List<Program> installedPrograms, int hp, int money = 0)
        {
            Money = money;
            MaxHP = hp;
            Hp = hp;
            BrainDamage = 0;
            Tags = 0;
            InstalledPrograms = installedPrograms;
        }

        public void PlayFromHand(Program program)
        {
            Time -= program.Cost;
            program.Play();
            Hand.Remove(program);
            Heap.Add(program);
        }

        public void StartBattle()
        {
            Stack = InstalledPrograms;
            new Rng(new Random()).Shuffle(Stack);
        }

        public void Draw(int amount = 1)
        {
            for (var i = 0; i < amount; i++)
            {
                if (Stack.Any(p => true))
                {
                    Hand.Add(Stack[0]);
                    Stack.RemoveAt(0);
                }
                else if (Heap.Any(p => true))
                {
                    Stack = Heap;
                    new Rng(new Random()).Shuffle(Stack);
                    Heap = new List<Program>();
                    Hand.Add(Stack[0]);
                    Stack.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }
        }
    }
}