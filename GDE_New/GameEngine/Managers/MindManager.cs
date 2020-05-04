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
    public class MindManager : IMindManager, IUpdate
    {
        /// <summary>
        /// PROPERTY: MindList, a property which provides access to a list of Minds
        /// </summary>
        public IList<IMind> MindList { get; set; }
        /// <summary>
        /// PROPERTY: MindToRemove, a property which provides access to a mind which needs to be removed
        /// </summary>
        public IMind MindsToRemove { get; set; }

        /// <summary>
        /// CONSTRUCTOR for MindManager
        /// </summary>
        public MindManager()
        {
            MindList = new List<IMind>();

        }

        #region IMindManager

        /// <summary>
        /// METHOD: CreateMind, a generic method which creates a type of T
        /// </summary>
        /// <typeparam name="T"> the type to make</typeparam>
        /// <param name="e"> the entity which the mind will possess </param>
        public IMind CreateMind<T>(IEntity e) where T : IMind, new()
        {
            // INSTANTIATE an IMind as a new type of T
            IMind m = new T();
            // CALL the possessEntity method, passing in the entity parameter
            m.possessEntity(e);
            // ADD the new mind to the list of minds
            MindList.Add(m);

            return m;
        }

        #endregion

        #region IUpdate
        public void Update(GameTime gameTime)
        {
            // FOREACH through each IUpdate in MindList
            foreach (IUpdate m in MindList)
            {
                // CALL to Update method on mind in list, passing in gameTime parameter
                m.Update(gameTime);
                // IF mind, cast as IMind, MindToRemove boolean is true 
                if ((m as IMind).MindToRemove)
                    // THEN SET MindsToRemove to m (cast as a IMind)
                    MindsToRemove = (m as IMind);
            }
        }
        #endregion
    }
}
