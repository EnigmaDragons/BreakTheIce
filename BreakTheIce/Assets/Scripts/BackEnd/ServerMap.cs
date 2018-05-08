using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMap
{
    private List<Node> nodes;

    public ServerMap(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }
}
