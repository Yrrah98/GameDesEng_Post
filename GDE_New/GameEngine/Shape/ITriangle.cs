using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Shape
{
    class ITriangle : IShape
    {

        public Vector2 Centre { get; private set; }

        public IList<Vector2> Points { get; private set; }

        public IList<Vector2> Edges { get; private set; }

        public ITriangle(Vector2 pFirstPoint)
        {

        }


        public void buildEdges()
        {

        }

        public void MakePoints(Vector2 firstPoint)
        {
            
        }
    }
}
