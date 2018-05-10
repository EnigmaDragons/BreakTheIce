using System.Collections.Generic;

public class Node
{
    public List<Node> Connections { get; set; }
    public NodeType Type { get; }

    protected Node(NodeType type)
    {
        Type = type;
    }
}