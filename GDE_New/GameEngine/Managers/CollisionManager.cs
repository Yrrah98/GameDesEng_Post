using GameEngine.Args;
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
    public class CollisionManager : IPublisher, ICollisionManager, IUpdate
    {
        // DECLARE an EventHandler of type EventArgs called OnCollisionEvent
        private EventHandler<EventArgs> OnCollisionEvent;

        private SceneEntitiesDelegate _sceneGraphEntities;

        private SceneEntitiesDelegate _staticEntities;

        public IQuadTree<IShape> QuadTree { get; private set; }

        public IQuadTree<IShape> StaticQuadTree { get; private set; }

        private ISat _sat;

        /// <summary>
        /// CONSTRUCTOR for class CollisionManager
        /// </summary>
        public CollisionManager(SceneEntitiesDelegate pSceneGraph,SceneEntitiesDelegate pStatics, IQuadTree<IShape> pQuadTree)
        {
            // SET _sceneGraphEntities delegat to the delegate passed into the 
            // constructor
            _sceneGraphEntities = pSceneGraph;
            // SET QuadTree to the QuadTree variable passed into the constructor
            QuadTree = pQuadTree;
            // SET _sat as a new type of SAT
            _sat = new SAT();

            _staticEntities = pStatics;

            QuadTree.SetDelegate(CheckEntityCollisions);
        }


        #region IUpdateableComp
        public void Update(GameTime gameTime)
        {
            // CALL AddEntity on quadTree variable, adding return data of the sceneGraph
            // this will rebuild the quad tree on each frame 
            QuadTree.AddEntity(_sceneGraphEntities());

            // CALL NodeCollisions method on the quad Tree
            QuadTree.NodeCollisions();


            for (int i = 0; i < _sceneGraphEntities().Count; i++)
            {
                for (int j = 0; j < _staticEntities().Count; j++)
                {

                    //if (_sceneGraphEntities()[i].Shape.Points[0].X <= _staticEntities()[j].Shape.Points[0].X + 32
                    //    && _staticEntities()[j].Shape.Points[0].X <= _sceneGraphEntities()[i].Shape.Points[0].X + 32
                    //    && _sceneGraphEntities()[i].Shape.Points[0].Y <= _staticEntities()[j].Shape.Points[0].Y + 48
                    //    && _staticEntities()[j].Shape.Points[0].Y <= _sceneGraphEntities()[i].Shape.Points[0].Y + 48)
                    //{
                    //    CheckEntityCollisions(_sceneGraphEntities()[i], _staticEntities()[j]);
                    //}

                    if (_sceneGraphEntities()[i].Shape.Points[0].X + 32 >= _staticEntities()[j].Shape.Points[0].X
                        && _sceneGraphEntities()[i].Shape.Points[0].X <= _staticEntities()[j].Shape.Points[0].X + 32
                        && _sceneGraphEntities()[i].Shape.Points[0].Y + 32 >= _staticEntities()[j].Shape.Points[0].Y
                        && _sceneGraphEntities()[i].Shape.Points[0].Y <= _staticEntities()[j].Shape.Points[0].Y + 32)
                    {
                        // THEN
                        // CALL delegate _checkCollisions, passing in the two entities
                        CheckEntityCollisions(_sceneGraphEntities()[i], _staticEntities()[j]);
                    }


                }
            }
        }
        #endregion


        #region ICollisionManager

        public void CheckEntityCollisions(IEntity e1, IEntity e2)
        {
            // INSTANTIATE 2 ILists of type Vector2 called axes1 and axes2
            // used to store a list of axes generated based on the entities points 
            // to generate axes, call to _sat method BuildAxes(), passing in each entity
            IList<Vector2> axes1 = _sat.BuildAxes(e1.Shape);
            IList<Vector2> axes2 = _sat.BuildAxes(e2.Shape);

            float minA = 0; float maxA = 0; float minB = 0; float maxB = 0;


            // IF the return value of _sat method OverLapCheck is true,
            if (_sat.OverlapCheck(axes1, axes2, e1.Shape, e2.Shape, ref minA, ref maxA, ref minB, ref maxB))
            {

                // THEN there has been a collision between the two entities
                // INSTANTIATE new OnCollisionEventArgs, passing in both the entities to
                // the constructor
                OnCollisionEventArgs args = new OnCollisionEventArgs(e1, e2, _sat.GetMTV());
                // CALL to NotifyListeners method, passing in the argument data
                notifyListners(args);
            }
        }

        #endregion

        #region Private Method

        private void notifyListners(OnCollisionEventArgs pArgs)
        {
            OnCollisionEvent(this, pArgs);
        }

        #endregion

        #region IPublisher
        public void Subscribe(EventHandler<EventArgs> pEventHandler)
        {
            OnCollisionEvent += pEventHandler;
        }

        public void UnSubscribe(EventHandler<EventArgs> pEventHandler)
        {
            OnCollisionEvent -= pEventHandler;
        }
        #endregion
    }
}
