using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace GameEngine.BaseEntity
{
    public abstract class StaticEntity : Entity
    {

        public float layerDepth { get; set; }

        public StaticEntity()
        {

        }

        public abstract void SetStaticPos(Vector2 pPos);
    }
}
