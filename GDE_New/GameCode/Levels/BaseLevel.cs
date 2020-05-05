using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Levels
{
    public abstract class BaseLevel : ILevel, IManagerInject, IUpdate
    {
        // DECLARE an IEntityManager called _entityManager
        protected IEntityManager _entityManager;
        // DECLARE an ICollisionManager called _collisionManager
        protected ICollisionManager _collisionManager;
        // DECLARE an IPublisher called _inputManager
        protected IPublisher _inputManager;
        // DECLARE an ISceneManager called _sceneManager
        protected ISceneManager _sceneManager;
        // DECLARE an IMindManager called _mindManager
        protected IMindManager _mindManager;
        // DECLARE a ContentManager called _contentManager;
        protected ContentManager _contentManager;

        public ILevel NextLevel { get; protected set; }

        /// <summary>
        /// PROPERTY: SwitchLevel, a property which allows a bool stating
        /// whether a level needs to be changed to be read 
        /// </summary>
        public bool SwitchLevel { get; protected set; }

        /// <summary>
        /// CONSTRUCTOR for BaseLevel class
        /// </summary>
        public BaseLevel()
        {

        }

        #region IManagerInject
        /// <summary>
        /// METHOD: InjectManagers, a method which injects the managers of the Engine into the level
        /// </summary>
        /// <param name="pEM"></param>
        /// <param name="pCM"></param>
        /// <param name="pIM"></param>
        /// <param name="pSM"></param>
        /// <param name="pMM"></param>
        public void InjectManagers(IEntityManager pEM, ICollisionManager pCM, 
            IPublisher pIM, ISceneManager pSM, IMindManager pMM, ContentManager pCntnt)
        {
            _entityManager = pEM;

            _collisionManager = pCM;

            _inputManager = pIM;

            _sceneManager = pSM;

            _mindManager = pMM;

            _contentManager = pCntnt;
        }
        #endregion

        #region IUpdate
        public virtual void Update(GameTime gameTime)
        {

        }
        #endregion

        #region ILevel
        public abstract SpriteBatch Draw(SpriteBatch spriteBatch);

        public abstract void Initialise();

        public abstract void LoadContent();

        public abstract void Unload();

        public abstract void PassMngers();
        #endregion

    }
}
