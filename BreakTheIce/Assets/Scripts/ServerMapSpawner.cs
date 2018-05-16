using System.Collections.Generic;
using Assets.Scripts.BackEnd;
using Assets.Scripts.FrontEnd;
using UnityEngine;

namespace Assets.Scripts
{
    public class ServerMapSpawner : MonoBehaviour
    {
        public GameObject Barrier;
        public GameObject Sentry;
        public GameObject CodeGate;
        public GameObject Boss;
        public GameObject Checkpoint;
        public GameObject Mystery;

        public void Start()
        {
            var nodeMap = new Dictionary<NodeType, GameObject>
            {
                { NodeType.Boss, Boss },
                { NodeType.Barrier, Barrier },
                { NodeType.CodeGate, CodeGate },
                { NodeType.Sentry, Sentry },
                { NodeType.Checkpoint, Checkpoint }
            };

            new ServerMapLayoutCalculation(GameData.Map).Get()
                .ForEach(x => Instantiate(nodeMap[x.Value.Type], x.Position, Quaternion.identity, transform));
        }
    }
}
