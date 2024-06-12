using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluid_Rope_Simulation
{
    internal class Spring
    {
        public Node NodeA { get; }
        public Node NodeB { get; }
        public float RestLength { get; }

        public const float K = 1000; // Spring constant


        public Spring(Node nodeA, Node nodeB)
        {
            NodeA = nodeA;
            NodeB = nodeB;
            RestLength = (float)Math.Sqrt((nodeB.Position.X - nodeA.Position.X) * (nodeB.Position.X - nodeA.Position.X) +
                                          (nodeB.Position.Y - nodeA.Position.Y) * (nodeB.Position.Y - nodeA.Position.Y));
        }

        public void ApplyForce()
        {
            PointF direction = new PointF(NodeB.Position.X - NodeA.Position.X, NodeB.Position.Y - NodeA.Position.Y);
            float distance = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            float displacement = RestLength - distance;
            direction.X /= distance;
            direction.Y /= distance;

            NodeA.Velocity = new PointF(displacement * K * direction.X, displacement * K * direction.Y);
            NodeB.Velocity = new PointF(displacement * K * direction.X, displacement * K * direction.Y);
        }
        public PointF CalculateForce()
        {
            PointF direction = new PointF(NodeB.Position.X - NodeA.Position.X, NodeB.Position.Y - NodeA.Position.Y);
            float distance = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            float displacement = distance - RestLength;
            float forceMagnitude = K * displacement;

            // Normalize direction
            direction.X /= distance;
            direction.Y /= distance;

            return new PointF(forceMagnitude * direction.X, forceMagnitude * direction.Y);
        }
    }
}
