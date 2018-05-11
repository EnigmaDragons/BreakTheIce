using System.Collections.Generic;

namespace Assets.Scripts.BackEnd
{
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
}
