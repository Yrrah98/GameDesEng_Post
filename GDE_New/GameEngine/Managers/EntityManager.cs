using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Managers
{
    public class EntityManager : IEntityManager
    {

        /// <summary>
        /// CONSTRUCTOR for EntityManager
        /// </summary>
        public EntityManager()
        {
        }

        public T CreateEntity<T>(ContentManager pContent) where T : IEntity, new()
        {
            // INSTANTIATE new type of T
            IEntity e = new T();

            // INITIALISE entity, passing in content parameter and sending in a new Guid ast to a string
            e.Initialise(pContent, Guid.NewGuid().ToString());

            // RETURN e
            return (T)e;
        }
    }
}
