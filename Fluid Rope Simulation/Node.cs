using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fluid_Rope_Simulation
{
    internal class Node
    {
        public Vector2 Position;
        public Vector2 PreviousPosition;
        public Vector2 Velocity;

        public Node(Vector2 position)
        {
            Position = position;
            PreviousPosition = position;
            Velocity = Vector2.Zero;
        }
    }
}
