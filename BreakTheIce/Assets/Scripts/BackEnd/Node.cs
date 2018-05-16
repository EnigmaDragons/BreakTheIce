using System.Collections.Generic;

namespace Assets.Scripts.BackEnd
{
    public class Node
    {
        public List<Node> Connections { get; } = new List<Node>();
        public NodeType Type { get; }

        public Node(NodeType type)
        {
            Type = type;
        }

        public void Connect(Node node)
        {
            Connections.Add(node);
            node.Connections.Add(this);
        }
    }
}