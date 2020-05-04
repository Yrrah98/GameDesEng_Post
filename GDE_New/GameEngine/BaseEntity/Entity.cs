using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.BaseEntity
{
    public abstract class Entity : IEntity, IUpdate
    {

        // DECLARE a variable of type String to store the entities unique Identifier
        protected String _uid;
        // DECLARE a variable of type bool to store a flag in the entity
        protected bool _remove;
        // Variable to store entities position
        public Vector2 Position { get; protected set; }
        // Variable to store entities texture2D
        public Texture2D Texture { get; protected set; }
        // DECLARE IList<Vector2> to store a list of points called _points
        protected IList<Vector2> _points;
        // DECLARE IList<Vector2> to store a list of edges called _edges
        protected IList<Vector2> _edges;

        protected float _rotation = 0;

        protected Vector2 _centre;

        public IShape Shape { get; protected set; }

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public Entity()
        {
            
        }

        /// <summary>
        /// METHOD: Update, a method called once per frame
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }


        public abstract void Initialise(ContentManager pContent, String pUID);

        #region PROPERTIES
        public bool Remove { get { return _remove; } set { _remove = value; } }

        public string UID { get { return _uid; } protected set { _uid = value; } }

        #endregion 



    }
}
