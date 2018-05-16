using System;

namespace Assets.Scripts.BackEnd.Programs
{
    public abstract class Program
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public string Text { get; private set; }
        private Action<Runner> action;

        protected Program(string name, int cost, string text, Action<Runner> action)
        {
            Name = name;
            Cost = cost;
            Text = text;
            this.action = action;
        }

        public void Play(Runner player)
        {
            action(player);
        }
    }
}
