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
    public class SceneManager : ISceneManager, IUpdate
    {
        /// <summary>
        /// PROPERTY: To access list of entities in the SceneManager
        /// </summary>
        public IList<IEntity> SceneMgrEList { get; set; }
        /// <summary>
        /// PROPERTY: To access an entity which needs to be removed from the world 
        /// </summary>
        public IEntity EToRemove { get; set; }

        private ISceneGraph _sceneGraph;

        /// <summary>
        /// CONSTRUCTOR for SceneManager
        /// </summary>
        public SceneManager()
        {
            SceneMgrEList = new List<IEntity>();

            _sceneGraph = new SceneGraph();
        }

        #region IUpdate

        public void Update(GameTime gameTime)
        {
        }
        #endregion

        #region ISceneManager

        public void RemoveFromScene(IEntity e)
        {
            _sceneGraph.RemoveSceneList(e);
        }

        /// <summary>
        /// METHOD: AddEntityWorld, a method which adds an entity to the world
        /// </summary>
        /// <param name="e"></param>
        public void AddEntityWorld(IEntity e)
        {
            // ADD entity passed in to SceneManagerList
            SceneMgrEList.Add(e);

            _sceneGraph.AddSceneList(e);
        }

        /// <summary>
        /// METHOD: RemoveEntityFromWorld a method which removes a specified entity from the world
        /// </summary>
        /// <param name="e"></param>
        public void RemoveEntityFromWorld(IEntity e)
        {
            // REMOVE entity passed in from the game world

            // REMOVE entity passed in from the SceneManager
            SceneMgrEList.Remove(e);
        }

        /// <summary>
        /// METHOD: SceneEntitiesDelegat, a method which calls 
        /// </summary>
        /// <returns></returns>
        public IList<IEntity> SceneEntitiesDelegate()
        {
            return _sceneGraph.InSceneList;
        }

        public void NextLevelStart()
        {
            
        }

        public IList<IEntity> StaticEntitiesDelegate()
        {
            return _sceneGraph.StaticEntitiesDelegate();
        }

        public SpriteBatch Draw(SpriteBatch spriteBatch)
        {

            foreach (Entity e in _sceneGraph.StaticEntities)
                spriteBatch.Draw(e.Texture, new Rectangle((int)e.Shape.Points[0].X, (int)e.Shape.Points[0].Y, 32, 32), Color.AntiqueWhite);

            // FOREACH loop through entities in sceneGraph list
            foreach (Entity e in _sceneGraph.InSceneList)
            {
                
                
                if (e is AnimateableEntity)
                {
                    // IF frameCounter is greater than the value of switchFrame 
                    if ((e as AnimateableEntity).frameCounter >= (e as AnimateableEntity).switchFrame)
                    {
                        // THEN CAST the possessed entity to GameXEntity and increment its 
                        // current x frame by 1 
                        ((AnimateableEntity)e).CurrentFrameX += 1;
                        // IF the possessedEntitys CurrentFrameX exceeds or is equal to 4
                        if (((AnimateableEntity)e).CurrentFrameX >= (e as AnimateableEntity).maxWidth)
                            // RESET it to 0
                            ((AnimateableEntity)e).CurrentFrameX = 0;

                        // RESET frameCounter to 0 to begin the loop again
                        (e as AnimateableEntity).frameCounter = 0;
                    }

                    spriteBatch.Draw(e.Texture,
                        new Rectangle((int)e.Shape.Points[0].X, (int)e.Shape.Points[0].Y, (e as AnimateableEntity).Width, (e as AnimateableEntity).Height),
                        new Rectangle((e as AnimateableEntity).Width * (e as AnimateableEntity).CurrentFrameX,
                        (e as AnimateableEntity).Height * (e as AnimateableEntity).CurrentFrameY, (e as AnimateableEntity).Width, (e as AnimateableEntity).Height), Color.AntiqueWhite);
                }
                if (e is SpeakingEntity)
                    if((e as SpeakingEntity).speechText != null)
                        spriteBatch.Draw((e as SpeakingEntity).speechText, new Rectangle(400, 600, (e as SpeakingEntity).speechText.Width, (e as SpeakingEntity).speechText.Height), Color.AntiqueWhite);


                //spriteBatch.Draw(e.Texture,
                //    new Vector2(e.Shape.Points[0].X, e.Shape.Points[0].Y),
                //    new Rectangle((int)e.Shape.Points[0].X + 16, (int)e.Shape.Points[0].Y + 16, 32, 32),
                //    e.Color,
                //    e.Rotation,
                //    new Vector2(16, 16),
                //    1f,
                //    SpriteEffects.None,
                //    0);

            }

            


            return spriteBatch;
        }
        #endregion
    }
}
