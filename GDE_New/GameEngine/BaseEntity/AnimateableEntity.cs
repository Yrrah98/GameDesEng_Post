using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BaseEntity
{
    public abstract class AnimateableEntity : Entity
    {
        /// <summary>
        /// PROPERTY: To access the current frame of the animation on the X axis
        /// </summary>
        public int CurrentFrameX { get; set; }
        /// <summary>
        /// PROPERTY: To access the current frame of the animation on Y axis
        /// </summary>
        public int CurrentFrameY { get; set; }

        public SoundEffect eSfx { get; protected set; }

        public bool active { get; set; }

        public int maxWidth { get; set; }

        public int maxHeight { get; set; }

        // DECLARE variable int called frameCounter
        public int frameCounter { get; set; }
        // DECLARE variable int called frameCounter
        public int switchFrame { get; protected set; }

        public Vector2 _velocity { get; set;}

        public int Height { get; set; }

        public int Width { get; set; }

        /// <summary>
        /// CONSTRUCTOR for AnimateableEntity class
        /// </summary>
        public AnimateableEntity()
        {
            active = false;

            switchFrame = 200;
        }

        public abstract void SetPosition(Vector2 pPos);
    }
}
