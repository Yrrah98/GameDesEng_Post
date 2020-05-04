using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Shape
{
    public class Polygon : IShape 
    {
        public Vector2 Centre { get; private set; }

        public IList<Vector2> Points { get; private set; }

        public IList<Vector2> Edges { get; private set; }

        public Polygon()
        {
            Points = new List<Vector2>();

            Edges = new List<Vector2>();

        }



        public void buildEdges()
        {
            Edges.Clear();
            // INSTANTIATE 2 Vector2s called vertices1 and vertices2
            // these will store the vertices of a shape
            Vector2 vertices1;
            Vector2 vertices2;

            // FORLOOP through the points in this shape
            for (int i = 0; i < Points.Count; i++)
            {
                // SET vertices1 to the value found at points i
                vertices1 = Points[i];
                // IF the value of i + 1 is greater than the count of points
                if (i + 1 >= Points.Count)
                {
                    // THEN we have come back around on ourselves
                    // SET the value of vertices 2 to value found at the first element of Points
                    vertices2 = Points[0];
                }
                // ELSE
                else
                {
                    // SET the value of vertices2 to the value found at i in the list of points (Points)
                    vertices2 = Points[i + 1];
                }

                // ADD a new vector to the list of edges
                // where the value of the vector 2 is vertices1 - vertices2
                // this gives the value of the edge between vertices1 and vertices2
                Edges.Add(vertices2 - vertices1);
            }
        }

        public void MakePoints(Vector2 pTopLeft)
        {
            Centre = new Vector2(pTopLeft.X + 16, pTopLeft.Y + 16);

            // top left vertices
            Points.Add(pTopLeft);
            // top right 
            Points.Add(new Vector2(pTopLeft.X + 32, pTopLeft.Y));
            // bottom right 
            Points.Add(new Vector2(pTopLeft.X + 32, pTopLeft.Y + 32));
            // bottom left
            Points.Add(new Vector2(pTopLeft.X, pTopLeft.Y + 32));
        }
    }
}
