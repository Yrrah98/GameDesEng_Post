using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Managers
{
    class SAT : ISat
    {
        // DECLARE a double called overlap
        private double overlap;
        // DECLARE a float ca;;ed _minIntervalDistance initialise to positive infinity
        private float _minIntervalDistance = float.PositiveInfinity;
        // DECLARE a Vector2 called _smallesAxis
        private Vector2 _smallestAxis;

        /// <summary>
        /// CONSTRUCTOR for SAT class
        /// </summary>
        public SAT()
        {

        }

        /// <summary>
        /// METHOD: BuildAxes, a method that builds the axes of a shape and returns it 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<Vector2> BuildAxes(IShape p)
        {
            // INSTANTIATE new list of vectors called Axes
            IList<Vector2> axes = new List<Vector2>();

            p.buildEdges();

            // FOR LOOP through the edges of the shape 
            for (int i = 0; i < p.Edges.Count; i++)
            {
                // ADD a new vector to the list of vectors swapping the x and y components
                // found in the list of edges at i and negating the Y component 
                axes.Add(new Vector2(-p.Edges[i].Y, p.Edges[i].X));

                // NORMALIZE the value of the vector at i 
                axes[i].Normalize();
            }

            // RETURN list of axes to called
            return axes;
        }

        /// <summary>
        /// METHOD: GetMTV, this is a method which calculates the minimum translation vector 
        /// and returns it 
        /// </summary>
        /// <returns></returns>
        public Vector2 GetMTV()
        {
            // SET the overlap value to the absolute value of the overlap
            overlap = Math.Abs(overlap);
            // DECLARE a Vector2 called mtv and set its value to the _smallest axis
            // multiplied by the overlap
            Vector2 mtv = _smallestAxis * (float)overlap;
            // RETURN mtv
            return mtv;
        }

        /// <summary>
        /// METHOD; OverlapCheck, a method which checks if two shapes are overlapping on the arbritary axes of each shape
        /// </summary>
        /// <param name="pAxes1"> set of axes of shape 1</param>
        /// <param name="pAxes2"> set of axes of shape 2</param>
        /// <param name="p1"> 1st shape </param>
        /// <param name="p2"> 2nd shape</param>
        /// <param name="minA"> minimum point value of shape 1</param>
        /// <param name="maxA"> maximum point value of shape 1</param>
        /// <param name="minB"> minimum point value of shape 2</param>
        /// <param name="maxB"> maximum point value of shape 2</param>
        /// <returns></returns>
        public bool OverlapCheck(IList<Vector2> pAxes1, IList<Vector2> pAxes2, IShape p1, IShape p2, 
            ref float minA, ref float maxA, ref float minB, ref float maxB)
        {
            overlap = 10000;

            // IF the list of axes is not null
            if (pAxes1 != null)
                // FOR LOOP through the axes
                for (int i = 0; i < pAxes1.Count; i++)
                {
                    // INSTANTIATE 2 local vectors to store a projection
                    // CALL the ProjectOntoAxis method, passing in the axis found at i and the first shape
                    Vector2 projection1 = ProjectOntoAxis(pAxes1[i], p1, ref minA, ref maxA);
                    // CALL the ProjectOntoAxis method, passing in the axis found at i and the second shape
                    Vector2 projection2 = ProjectOntoAxis(pAxes1[i], p2, ref minB, ref maxB);

                    // X is used to represent the minimum value of a projection and Y to represent the maximum
                    // IF projection1s min value is greature than projection2s max OR 
                    // IF projection2s min is greater than projections1s max
                    if (projection1.X > projection2.Y || projection2.X > projection1.Y)
                    {
                        overlap = 10000;
                        _minIntervalDistance = float.PositiveInfinity;
                        _smallestAxis = new Vector2();
                        // THEN RETURN FALSE
                        return false;
                    }
                    else
                    {
                        double o;

                        if (projection1.X < projection2.Y)
                        {
                            o = projection2.X - projection1.Y;
                        }
                        else
                        {
                            o = projection1.X - projection2.Y;
                        }

                        if (o < overlap)
                        {
                            overlap = o;
                            _smallestAxis = pAxes1[i];
                        }
                    }
                }
            // DO THE SAME FOR THE SECOND LIST OF AXES 
            if (pAxes2 != null)
                for (int i = 0; i < pAxes2.Count; i++)
                {
                    Vector2 projection1 = ProjectOntoAxis(pAxes2[i], p1, ref minA, ref maxA);
                    Vector2 projection2 = ProjectOntoAxis(pAxes2[i], p2, ref minB, ref maxB);

                    if (projection1.X > projection2.Y || projection2.X > projection1.Y)
                    {
                        overlap = 10000;
                        _minIntervalDistance = float.PositiveInfinity;
                        _smallestAxis = new Vector2();
                        return false;
                    }
                    else
                    {
                        double o;

                        if (projection1.X < projection2.Y)
                        {
                            o = projection2.X - projection1.Y;
                        }
                        else
                        {
                            o = projection1.X - projection2.Y;
                        }

                        if (o < overlap)
                        {
                            overlap = o;
                            _smallestAxis = pAxes2[i];
                        }
                    }
                }
            // If neither of the if statements returned false then there has been a collision
            // so return true
            return true;
        }

        /// <summary>
        /// METHOD: ProjectOntoAxis a method which projects a shape onto an axis and returns the minimum and maximum values of 
        /// its projection
        /// </summary>
        /// <param name="pAxis"></param>
        /// <param name="pPolygon"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public Vector2 ProjectOntoAxis(Vector2 pAxis, IShape pPolygon, ref float min, ref float max)
        {
            // INSTANTIATE a float and store the dot product of the axis and the shapes
            // first point
            min = Vector2.Dot(pAxis, pPolygon.Points[0]);
            // INSTANTIATE a float as the value of min to start with 
            max = min;
            // FORLOOP through the points contained in the shape 
            for (int i = 0; i < pPolygon.Points.Count; i++)
            {
                // INSTANTIATE a float called p to store the dot product of the axis and vector found in
                // shapes list of points
                float p = Vector2.Dot(pAxis, pPolygon.Points[i]);
                // IF the value of p is less than the minimum value currently stored
                if (p < min)
                    // THEN
                    // SET min to the value of p 
                    min = p;
                // ELSE IF the value of p is greater than the value of max 
                if (p > max)
                    // THEN set the value of max to p 
                    max = p;
            }


            // INSTANTIATE a new local vector called projection
            // set its x to the value of min and y to the value of max
            Vector2 projection = new Vector2(min, max);
            // NORMALIZE projection variable
            projection.Normalize();
            // RETURN projection to caller 
            return projection;
        }
    }
}
