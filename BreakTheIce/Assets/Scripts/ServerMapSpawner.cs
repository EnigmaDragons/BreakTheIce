using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.BackEnd;
using Assets.Scripts.FrontEnd;
using UnityEngine;

namespace Assets.Scripts
{
    public class ServerMapSpawner : MonoBehaviour
    {
        public NodeComponent Barrier;
        public NodeComponent Sentry;
        public NodeComponent CodeGate;
        public NodeComponent Boss;
        public NodeComponent Checkpoint;
        public ParticleLineGenerator ServerLine;

        public void Start()
        {
            var nodeMap = CreateNodeTypeMap();
            var nodes = SpawnNodeGameObjects(nodeMap);
            SpawnLinesBetweenNodes(nodes);
        }

        private Dictionary<NodeType, NodeComponent> CreateNodeTypeMap()
        {
            return new Dictionary<NodeType, NodeComponent>
            {
                {NodeType.Boss, Boss},
                {NodeType.Barrier, Barrier},
                {NodeType.CodeGate, CodeGate},
                {NodeType.Sentry, Sentry},
                {NodeType.Checkpoint, Checkpoint}
            };
        }

        private List<NodeComponent> SpawnNodeGameObjects(Dictionary<NodeType, NodeComponent> nodeMap)
        {
            return new ServerMapLayoutCalculation(GameData.Map).Get().Select(x =>
                {
                    var component = Instantiate(nodeMap[x.Value.Type], x.Position, Quaternion.identity, transform);
                    component.Node = x.Value;
                    return component;
                }).ToList();
        }

        private void SpawnLinesBetweenNodes(List<NodeComponent> nodes)
        {
            var nodeLinesCreated = new List<List<Node>>();

            nodes.ForEach(component => component.Node.Connections
                .Where(connectedNode => !nodeLinesCreated
                    .Any(connectedLine => connectedLine.Contains(connectedNode)
                                       && connectedLine.Contains(component.Node)))
                .ForEach(connectedNode => SpawnLine(nodes, nodeLinesCreated, connectedNode, component)));
        }

        private void SpawnLine(List<NodeComponent> nodes, List<List<Node>> nodeLinesCreated, Node connectedNode, NodeComponent component)
        {
            nodeLinesCreated.Add(new List<Node> { connectedNode, component.Node });
            var line = Instantiate(ServerLine, transform);
            line.Source = component.transform.position;
            line.Dest = nodes.First(x => x.Node == connectedNode).transform.position;
            line.gameObject.SetActive(true);
        }
    }
}
