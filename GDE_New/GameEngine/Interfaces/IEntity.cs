using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace GameEngine.Interfaces
{
    public interface IEntity
    {

        IShape Shape { get; }

        /// <summary>
        /// PROPERTY: Get and Set a bool to signify whether the entity needs to be removed
        /// </summary>
        bool Remove { get; set; }

        /// <summary>
        /// PROPERTY: Get the Entities Unique Identifier 
        /// </summary>
        String UID { get; }

        /// <summary>
        /// METHOD: InitialiseContent, a method to initialise the content manager in the entity
        /// </summary>
        /// <param name="pContent"></param>
        void Initialise(ContentManager pContent, String pUID);

    }
}
