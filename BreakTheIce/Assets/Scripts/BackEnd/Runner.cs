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
        public IRandom Random { get; }

        public List<Program> Deck { get; private set; }
        public List<Program> Stack { get; private set; } = new List<Program>();
        public List<Program> Hand { get; private set; } = new List<Program>();
        public List<Program> Heap { get; private set; } = new List<Program>();

        public Runner(IRandom random, List<Program> deck, int hp, int money = 0)
        {
            Random = random;
            Money = money;
            MaxHP = hp;
            Hp = hp;
            BrainDamage = 0;
            Tags = 0;
            Deck = deck.ToList();
        }

        public void PlayFromHand(Program program)
        {
            Time -= program.TimeCost;
            program.Play(this);
            Hand.Remove(program);
            Heap.Add(program);
        }

        public void StartBattle()
        {
            Stack = Deck;
            Random.Shuffle(Stack);
            Time = 3;
        }

        public void Draw(int amount = 1)
        {
            for (var i = 0; i < amount; i++)
            {
                if (Stack.Any(p => true))
                    MoveProgramFrom(Stack, Hand, 0);
                else if (Heap.Any(p => true))
                {
                    ShuffleHeapIntoStack();
                    MoveProgramFrom(Stack, Hand, 0);
                }
                else
                    break;
            }
        }

        public void ShuffleHeapIntoStack()
        {
            Stack = Heap;
            Random.Shuffle(Stack);
            Heap = new List<Program>();
        }

        public void GainMaxHp(int amount)
        {
            MaxHP += amount;
        }

        private void MoveProgramFrom(IList<Program> origin, IList<Program> destination, int index)
        {
            destination.Add(origin[index]);
            origin.RemoveAt(index);
        }
    }
}