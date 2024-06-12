using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid_Rope_Simulation
{
    class Rope
    {
        private List<Node> nodes;
        private float nodeDistance;
        private int numNodes;

        public Rope(Vector2 startPosition, float nodeDistance, int numNodes)
        {
            this.nodeDistance = nodeDistance;
            this.numNodes = numNodes;
            nodes = new List<Node>();

            for (int i = 0; i < numNodes; i++)
            {
                nodes.Add(new Node(startPosition + new Vector2(0, i * nodeDistance)));
            }
        }

        public void Update(float deltaTime)
        {
            // Apply Verlet Integration
            foreach (var node in nodes)
            {
                Vector2 temp = node.Position;
                node.Position += (node.Position - node.PreviousPosition) + node.Velocity * deltaTime * deltaTime;
                node.PreviousPosition = temp;

                // Gravity
                node.Velocity += new Vector2(0, 9.81f) * deltaTime;
            }

            // Apply Constraints
            for (int i = 0; i < 5; i++)
            {
                ApplyConstraints();
            }
        }

        private void ApplyConstraints()
        {
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                Node node1 = nodes[i];
                Node node2 = nodes[i + 1];

                Vector2 delta = node2.Position - node1.Position;
                float distance = delta.Length();
                float difference = (distance - nodeDistance) / distance;

                Vector2 offset = delta * difference * 0.5f;
                node1.Position -= offset;
                node2.Position += offset;
            }
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                g.DrawLine(Pens.Black, nodes[i].Position.ToPoint(), nodes[i + 1].Position.ToPoint());
            }
        }
    }
}
