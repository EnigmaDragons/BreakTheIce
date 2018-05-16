using System.Collections.Generic;
using Assets.Scripts.BackEnd;
using UnityEngine;

namespace Assets.Scripts
{
    public class InitGame : MonoBehaviour
    {
        public List<GameObject> ToSpawn;

        public void Start()
        {
            var nodes = new List<Node>
            {
                new Node(NodeType.Boss),
                new Node(NodeType.Barrier),
                new Node(NodeType.CodeGate),
                new Node(NodeType.Sentry),
                new Node(NodeType.Checkpoint)
            };
            nodes[0].Connect(nodes[1]);
            nodes[0].Connect(nodes[2]);
            nodes[1].Connect(nodes[3]);
            nodes[2].Connect(nodes[4]);
            nodes[3].Connect(nodes[4]);

            GameData.Map = new ServerMap(nodes);

            ToSpawn.ForEach(x => Instantiate(x));
        }
    }
}
