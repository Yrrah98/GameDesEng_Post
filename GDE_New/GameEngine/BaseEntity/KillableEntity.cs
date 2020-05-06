using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.BaseEntity
{
    public abstract class KillableEntity : AnimateableEntity
    {
        // DECLARE a Rectangle called _hpAreaG 
        public Rectangle _hpAreaG { get; protected set; }
        // DECLARE a Rectangled called _hpAreaR
        public Rectangle _hpAreaR { get; protected set; }
        // DECLARE a Texture2D called GreenTxtr
        public Texture2D GreenTxtr { get; protected set; }
        // DECLARE a Texture2D called RedTxtr - could replace textures with white texture
        // then use Red and Green overals respectively in the draw method
        public Texture2D RedTxtr { get; protected set; }
        // DECLARE int called _hpWidthMax
        public int _hpWidthMax { get; protected set; }
        // DECLARE int called _hpWidthCurr
        public int _hpWidthCurr { get; protected set; }
        // DECLARE a Vector2 called _hpPos
        public Vector2 _hpPos { get; protected set; }

        public KillableEntity()
        {

        }

        public abstract void TakeDamage(int pDmg);
    }
}
