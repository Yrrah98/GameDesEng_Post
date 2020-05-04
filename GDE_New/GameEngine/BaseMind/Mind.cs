using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BaseMind
{
    public class Mind : IMind, IUpdate, ICollisionListener, IInputListener
    {

        // DECLARE variable IEntity called possessedEntity to store the possessed entity
        protected IEntity possessedEntity;
        // DECLARE variable bool called mindToRemove
        protected bool mindToRemove;
        // DECLARE variable int called frameCounter
        protected int frameCounter;
        // DECLARE variable int called frameCounter
        protected int switchFrame = 200;

        /// <summary>
        /// CONSTRUCTOR for abstract class MindX
        /// </summary>
        public Mind()
        {

        }

        #region ICollisionListener
        public virtual void OnCollisionEvent(object source, EventArgs pArgs)
        {

        }
        #endregion

        #region IInputListener
        public virtual void OnInputEvent(object source, EventArgs pArgs)
        {

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// METHOD: possessEntity, a method to store the possessedEntity in a variable
        /// </summary>
        /// <param name="e"></param>
        public virtual void possessEntity(IEntity e)
        {
            possessedEntity = e;
        }


        #region PROPERTIES
        /// <summary>
        /// PROPERTY: PossessedEntity, a property to provide access for the possessedEntity variable
        /// </summary>
        public IEntity PossessedEntity
        {
            get { return possessedEntity; }
            set { possessedEntity = value; }
        }

        /// <summary>
        /// PROPERTY: MindToRemove, a property to provide access for the mindToRemove boolean
        /// </summary>
        public bool MindToRemove
        {
            get { return mindToRemove; }
            set { mindToRemove = value; }
        }
        #endregion
    }
}
