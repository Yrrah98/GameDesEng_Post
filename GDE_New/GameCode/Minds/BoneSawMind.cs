using GameEngine.BaseEntity;
using GameEngine.BaseMind;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Minds
{
    class BoneSawMind : Mind
    {

        public BoneSawMind()
        {

        }

        public override void Update(GameTime gameTime)
        {
            (possessedEntity as AnimateableEntity).active = true;

            if ((possessedEntity as AnimateableEntity).active)
            {
                (possessedEntity as AnimateableEntity).frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
                (possessedEntity as AnimateableEntity).frameCounter = 0;

            base.Update(gameTime);
        }
    }
}
