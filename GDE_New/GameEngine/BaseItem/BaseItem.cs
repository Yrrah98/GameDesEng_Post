using GameEngine.BaseEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BaseItem
{
    public abstract class BaseItem : AnimateableEntity
    {

        public bool Stored { get; set; }

        public BaseItem()
        {

        }
    }
}
