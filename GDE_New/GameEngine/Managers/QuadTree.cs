using GameEngine.BaseEntity;
using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Managers
{
    public class QuadTree<T> : IQuadTree<T> where T : IShape
    {

        // DECLARE constant int called MAX_ENTITIES to store the maximum number of entities a node can possibly store
        private const int MAX_ENTITIES = 8;
        // DECLARE constant int call MAX_LEVELS to store the maximum number of times the tree can divide 
        private const int MAX_LEVELS = 5;
        // DECLARE a IList<IEntity> called _entityList
        private IList<IEntity> _entityList;
        // DECLARE type int called _nodeLevel to store the level of this quad 
        private int _nodeLevel;
        // DECLARE type Rectangle called _nodeRectangle to store this nodes rectangle
        private Rectangle _nodeRectangle;
        // DECLARE type Texture2D called _rectTexture to store this nodes texture
        private Texture2D _rectTexture;
        // DECLARE IList<IQuadTree<T>> called _quads to store a list of quad trees
        private IList<IQuadTree<T>> _quads;
        // DECLARE delegate of type CheckEntityCollisions called _checkCollisions
        private CheckEntityCollisions _checkCollisions;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        /// <param name="pRootRect"></param>
        /// <param name="pLevel"></param>
        /// <param name="pTxtr"></param>
        public QuadTree(Rectangle pRootRect, int pLevel)
        {
            // INITIALISE variables to parameters sent in 
            // _nodeRectangle set to pRootRect
            this._nodeRectangle = pRootRect;
            // _nodeLevel = pLevel
            _nodeLevel = pLevel;
        }

        /// <summary>
        /// METHOD: SetDelegate, a method used to set the delegate of the node
        /// </summary>
        /// <param name="pCheckCollisions"></param>
        public void SetDelegate(CheckEntityCollisions pCheckCollisions)
        {
            // SET _checkCollisions delegate to the parameter passed into method
            _checkCollisions = pCheckCollisions;
        }

        /// <summary>
        /// METHOD: AddEntity to add entities into the quad tree
        /// </summary>
        /// <param name="e"></param>
        public void AddEntity(IList<IEntity> e)
        {
            // CALL to Clear method
            Clear();

            // IF the list of entities is null 
            if (_entityList == null)
                // THEN
                // INSTANTIATE the list of entities 
                _entityList = new List<IEntity>();

            // CAST _entityList to type List<IEntity> to use AddRange method 
            // so all entities in parameter passed in are put into the list
            ((List<IEntity>)_entityList).AddRange(e);

            // IF the list of entities in this quad is greater than the MAX_ENTITIES
            if (this._entityList.Count >= MAX_ENTITIES)
            {
                // THEN
                // CALL SubDivide in this quad
                SubDivide();
            }
        }

        /// <summary>
        /// METHOD: NodeCollisions, a method which performs a preliminary check to see if entities are potentially colliding
        /// if they are, then they are passed to the collision manager for further collision testing
        /// </summary>
        public void NodeCollisions()
        {
            // FORLOOP through _entity list
            for (int i = 0; i < _entityList.Count; i++)
            {
                // FORLOOP through _entityList again, but +1
                for (int j = i + 1; j < _entityList.Count; j++)
                    // IF min and max x,y values of one entity overlap with another entities min and max x.y values 
                    // values are computed on the fly, further improvement could be to use AABB collision for the preliminary check
                    if (_entityList[i].Shape.Points[0].X >= _entityList[j].Shape.Points[0].X - 32
                        && _entityList[i].Shape.Points[0].X - 32 <= _entityList[j].Shape.Points[0].X
                        && _entityList[i].Shape.Points[0].Y + 32 >= _entityList[j].Shape.Points[0].Y
                        && _entityList[i].Shape.Points[0].Y <= _entityList[j].Shape.Points[0].Y + 32)
                    {
                        // THEN
                        // CALL delegate _checkCollisions, passing in the two entities
                        _checkCollisions(_entityList[i], _entityList[j]);
                    }
                // IF _quads is not null
                if (_quads != null)
                {
                    // THEN FOREACH through it 
                    foreach (IQuadTree<T> q in _quads)
                        // FOREACH through each quads list of entities
                        foreach (IEntity e in q.Entities)
                            // IF the entities of the list are potentially overlapping with any of the entities in the child quads
                            // again, these values are computed on the fly and could be improved upon by making use of an AABB and projecting onto x and y axis
                            if (_entityList[i].Shape.Points[0].X >= e.Shape.Points[0].X - 32
                                && _entityList[i].Shape.Points[0].X - 32 <= e.Shape.Points[0].X
                                && _entityList[i].Shape.Points[0].Y + 32 >= e.Shape.Points[0].Y
                                && _entityList[i].Shape.Points[0].Y <= e.Shape.Points[0].Y + 32)
                            {
                                Console.WriteLine("collision happening");
                                // THEN CALL _checkCollisions method, sending both entities into it
                                _checkCollisions(_entityList[i], e);
                            }
                }

            }



            // IF _quads is not null
            if (_quads != null)
                // THEN FOREACH through the list of quads
                foreach (IQuadTree<T> q in _quads)
                    // CALL to NodeCollisions method in each quad
                    q.NodeCollisions();
        }

        /// <summary>
        /// METHOD: Clear, a method which is used to clear out all the lists contained in each quad
        /// and calls the clear method in the children quads
        /// </summary>
        public void Clear()
        {
            // IF _entityList is not null
            if (_entityList != null)
                // CLEAR entity list out
                _entityList.Clear();

            // IF _quads is not null
            if (_quads != null)
                // THEN FOREACH through the list of quads
                foreach (IQuadTree<T> q in _quads)
                    // CALL to clear method on each quad 
                    q.Clear();

            // NULL the _quads variable, ready for re-insertion
            _quads = null;
            // NULL the entity list, ready for re-insertion
            _entityList = null;
        }

        /// <summary>
        /// METHOD: SubDivide, a method which sub divides a quad tree into 4 smaller quad trees
        /// </summary>
        public void SubDivide()
        {
            // IF _quads is null
            if (_quads == null)
            {
                // SET UP the new width, height, x and y for the child nodes, based on the width of the parent node and the far left and top of the parent node
                int w = _nodeRectangle.Width / 2;
                int h = _nodeRectangle.Height / 2;
                int x = _nodeRectangle.Left;
                int y = _nodeRectangle.Top;

                _quads = new List<IQuadTree<T>>();

                // THEN 
                // INITIALISE 4 new QuadTrees, sending in a new Rectangle corresponding to a "top left", "top right", "bottom left", "bottom right"
                _quads.Add(new QuadTree<T>(new Rectangle(x, y, w, h), _nodeLevel));
                _quads.Add(new QuadTree<T>(new Rectangle(x + w, y, w, h), _nodeLevel));
                _quads.Add(new QuadTree<T>(new Rectangle(x, y + h, w, h), _nodeLevel));
                _quads.Add(new QuadTree<T>(new Rectangle(x + w, y + h, w, h), _nodeLevel));

                // FOREACH quadtree in _quads
                foreach (IQuadTree<T> q in _quads)
                    // CALL SetDelegate method and pass in the delegate stored in this node
                    q.SetDelegate(_checkCollisions);
            }

            // FOREACH IQuadTree<T> in list of quads
            foreach (IQuadTree<T> q in _quads)
            {
                IList<IEntity> nList = new List<IEntity>();
                // THEN 
                // FOREACH IEntity in the _entityList
                foreach (IEntity e in _entityList)
                    // THEN IF current quad tree in list of quads contains entity rectangle 
                    if (q.NodeRectangle.Contains(e.Shape.Points[0]) && q.NodeLevel < MAX_LEVELS)
                    {
                        // THEN 
                        // ADD entity in list to quad 
                        nList.Add(e);
                    }

                q.AddEntity(nList);
                // IF quad list of entities is not null
                if (q.Entities != null)
                {
                    // THEN FOREACH through list of entities in the quad
                    foreach (IEntity b in q.Entities)
                        // IF the entity list of THIS class (the parent) contains the entity which can be found in its child
                        if (_entityList.Contains(b))
                        {
                            // THEN REMOVE that entity from the the parents list of entities
                            _entityList.Remove(b);
                        }
                }
            }

        }


        #region PROPERTIES

        public int NodeLevel { get { return _nodeLevel; } }

        /// <summary>
        /// PROPERTY to acces the list of entities
        /// </summary>
        public IList<IEntity> Entities
        {
            get { return _entityList; }
            set { _entityList = value; }
        }

        /// <summary>
        /// PROPERTY to access the quad trees texture
        /// </summary>
        public Texture2D RectText
        {
            get { return _rectTexture; }
            set { _rectTexture = value; }
        }

        /// <summary>
        /// PROPERTY to acces the quad trees rectangle
        /// </summary>
        public Rectangle NodeRectangle
        {
            get { return _nodeRectangle; }
            set { _nodeRectangle = value; }
        }

        #endregion
    }
}
