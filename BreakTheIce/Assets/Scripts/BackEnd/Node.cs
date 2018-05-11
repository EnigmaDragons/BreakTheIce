using System.Collections.Generic;

namespace Assets.Scripts.BackEnd
{
    public class Node
    {
        public List<Node> Connections { get; set; }
        public NodeType Type { get; }

        protected Node(NodeType type)
        {
            Type = type;
        }
    }
}