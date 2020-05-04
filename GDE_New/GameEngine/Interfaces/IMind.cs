using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface IMind
    {

        /// <summary>
        /// METHOD: possessEntity, a method to store the possessedEntity in a variable
        /// </summary>
        /// <param name="e"></param>
        void possessEntity(IEntity e);

        /// <summary>
        /// PROPERTY: PossessedEntity, a property to provide access for the possessedEntity variable
        /// </summary>
        IEntity PossessedEntity { get; set; }

        /// <summary>
        /// PROPERTY: MindToRemove, a property to provide access for the mindToRemove boolean
        /// </summary>
        bool MindToRemove { get; set; }
    }
}
