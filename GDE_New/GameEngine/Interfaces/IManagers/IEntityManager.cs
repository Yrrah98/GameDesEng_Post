using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface IEntityManager 
    {
        /// <summary>
        /// METHOD: CreateEntity, a method to create an entity of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T CreateEntity<T>(ContentManager pContent) where T : IEntity, new();
    }
}
