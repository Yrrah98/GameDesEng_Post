using GameEngine.BaseEntity;
using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Managers
{
    class SceneGraph : ISceneGraph
    {
        /// <summary>
        /// PROPERTY for InSceneList list of entities
        /// </summary>
        public IList<IEntity> InSceneList { get; set; }

        public IList<IEntity> StaticEntities { get; set; }

        /// <summary>
        /// CONSTRUCTOR for SceneGraph
        /// </summary>
        public SceneGraph()
        {
            InSceneList = new List<IEntity>();

            StaticEntities = new List<IEntity>();
        }

        #region ISceneGraph
        /// <summary>
        /// METHOD: AddSceneList, a method which adds an entity to the scene graph
        /// </summary>
        /// <param name="e"></param>
        public void AddSceneList(IEntity e)
        {
            // CALL to Add method of the list of entities
            if (e is StaticEntity)
            {
                StaticEntities.Add(e);
            }
            else
            { 
                InSceneList.Add(e);
            }
        }
        /// <summary>
        /// METHOD: RemoveSceneList, a method which removes an entity from the SceneGraph
        /// </summary>
        /// <param name="e"></param>
        public void RemoveSceneList(IEntity e)
        {
            // CALL to Remove method in the list of entities

            if (InSceneList.Contains(e))
                InSceneList.Remove(e);
            else if (StaticEntities.Contains(e))
                StaticEntities.Remove(e);
        }
        /// <summary>
        /// METHOD: SceneEntitiesDelegate, a method which will be used to return 
        /// the list of entities in the SceneGraph
        /// </summary>
        /// <returns></returns>
        public IList<IEntity> SceneEntitiesDelegate()
        {
            // RETURN list of entities in SceneGraph
            return InSceneList;
        }

        public IList<IEntity> StaticEntitiesDelegate()
        {
            return StaticEntities;
        }
        #endregion
    }
}
