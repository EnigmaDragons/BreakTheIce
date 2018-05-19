using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.BackEnd;
using UnityEngine;

namespace Assets.Scripts.FrontEnd
{
    public class ServerMapLayoutCalculation
    {
        private readonly ServerMap _map;

        public ServerMapLayoutCalculation(ServerMap map)
        {
            _map = map;
        }

        public List<PositionedNode> Get()
        {
            var takenSpots = new List<Vector3>();
            return _map.GetNodes().Select(x =>
            {
                var vector = Vector3.zero;
                while (takenSpots.Any(spot => spot.x == vector.x && spot.z == vector.z))
                    vector = new Vector3(Random.Range(-4, 4) * 2, 0, Random.Range(-4, 4) * 2);
                takenSpots.Add(vector);
                return new PositionedNode(x, vector);
            }).ToList();
        }
    }
}
