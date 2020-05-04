using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface IShape
    {

        /// <summary>
        /// METHOD: MakePoints, a method which is used to create the points of a shape
        /// </summary>
        void MakePoints(Vector2 firstPoint);

        /// <summary>
        /// METHOD: buildEdges, a method which is used to create the edges of the shape. 
        /// </summary>
        void buildEdges();

        /// <summary>
        /// PROPERTY: Centre, a property to return the centre of the shape
        /// </summary>
        Vector2 Centre { get; }

        /// <summary>
        /// PROPERTY: Points, a property to return the list of points
        /// </summary>
        IList<Vector2> Points { get; }

        /// <summary>
        /// PROPERTY: Edges, a property to return the list of edges 
        /// </summary>
        IList<Vector2> Edges { get; }
    }
}
