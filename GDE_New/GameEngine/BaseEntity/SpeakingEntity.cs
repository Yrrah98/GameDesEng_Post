using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BaseEntity
{
    public abstract class SpeakingEntity : AnimateableEntity
    {

        public String speech;

        public SpriteFont sF { get; set; }

        public Texture2D speechText;

        public SpeakingEntity()
        {

        }
    }
}
