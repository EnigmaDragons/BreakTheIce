using Assets.Scripts.BackEnd;
using UnityEngine;

namespace Assets.Scripts.FrontEnd
{
    public class PositionedNode
    {
        public Node Value { get; }
        public Vector3 Position { get; }

        public PositionedNode(Node value, Vector3 position)
        {
            Value = value;
            Position = position;
        }
    }
}
