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
    public class SceneManager : ISceneManager, IUpdate, IUnload
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

        #region IUnload
        public void Unload()
        {
            _sceneGraph.InSceneList.Clear();

            _sceneGraph.StaticEntities.Clear();



            //_sceneGraph.InSceneList = new List<IEntity>();
        }
        #endregion

        #region IUpdate

        public void Update(GameTime gameTime)
        {
            foreach (IEntity e in _sceneGraph.InSceneList)
                if (e.Remove)
                    EToRemove = e;

            foreach (IEntity s in _sceneGraph.StaticEntities)
                if (s.Remove)
                    EToRemove = s;

            if (EToRemove != null)
                RemoveFromScene(EToRemove);
        }
        #endregion

        #region ISceneManager

        public void RemoveFromScene(IEntity e)
        {
            _sceneGraph.RemoveSceneList(e);

            EToRemove = null;
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
                // IF e is Killable
                if (e is KillableEntity)
                {
                    // THEN
                    // LOCAL Rectangle called G to store the green portion of hp bar. Width is the current health amount 
                    Rectangle G = new Rectangle((int)(e as KillableEntity)._hpPos.X, (int)(e as KillableEntity)._hpPos.Y, (e as KillableEntity)._hpWidthCurr, 16);
                    // LOCAL Rectangle called R to store the red portion of the hp bar, position is green bar + greens width and width is the value 
                    // of the maximum health subtracted by the current health 
                    Rectangle R = new Rectangle(G.X + G.Width , (int)(e as KillableEntity)._hpPos.Y, (e as KillableEntity)._hpWidthMax - (e as KillableEntity)._hpWidthCurr, 16);
                    // DRAW the Green and Red HP bars
                    spriteBatch.Draw((e as KillableEntity).GreenTxtr, G, Color.AntiqueWhite);
                    spriteBatch.Draw((e as KillableEntity).RedTxtr, R, Color.AntiqueWhite);
                }

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

            }

            


            return spriteBatch;
        }
        #endregion
    }
}
