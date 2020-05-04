using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface ISat
    {

        Vector2 GetMTV();

        /// <summary>
        /// METHOD: ProjectOntoAxis -  a method where 
        /// points of a polygon are projected onto an axis to check for overlap
        /// /// </summary>
        /// <param name="pAxis">Axis which will be projected onto</param>
        /// <param name="pPolygon">polygon which will contain points
        /// which need to be projected
        /// </param>
        /// <returns></returns>
        Vector2 ProjectOntoAxis(Vector2 pAxis, IShape pPolygon, ref float min, ref float max);

        /// <summary>
        /// METHOD: BuildAxes, a method which will be used to build the axes
        /// of a polygon
        /// </summary>
        /// <param name="p">polygon which contains the edges
        /// which will be built into an axis</param>
        /// <returns></returns>
        IList<Vector2> BuildAxes(IShape p);

        /// <summary>
        /// METHOD: OverlapCheck, a method which will return true 
        /// if there is an overlap on all axes of both polygons
        /// </summary>
        /// <param name="pAxes1"></param>
        /// <param name="pAxes2"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        bool OverlapCheck(IList<Vector2> pAxes1, IList<Vector2> pAxes2, IShape p1, IShape p2,
            ref float minA, ref float maxA, ref float minb, ref float maxB);
    }
}
