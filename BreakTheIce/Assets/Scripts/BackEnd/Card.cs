using System;

namespace Assets.Scripts.BackEnd
{
    public class Card
    {
        public int Cost { get; private set; }
        public string Text { get; private set; }
        private Action action;

        public Card(int cost, string text, Action action)
        {
            Cost = cost;
            Text = text;
            this.action = action;
        }

        public void Play()
        {
            action();
        }
    }
}
