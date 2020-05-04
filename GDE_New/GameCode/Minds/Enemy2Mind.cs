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
    class Enemy2Mind : Mind
    {

        private Vector2 startPos;

        private bool stored;

        public Enemy2Mind()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (!stored)
            {
                startPos = ((possessedEntity as AnimateableEntity).Position);
                stored = !stored;
            }

            for (int i = 0; i < (possessedEntity as AnimateableEntity).Shape.Points.Count; i++)
            {
                (possessedEntity as AnimateableEntity).Shape.Points[i] += (possessedEntity as AnimateableEntity)._velocity;


            }

            if ((possessedEntity as AnimateableEntity).Shape.Points[0].X <= startPos.X - 60)
            {
                (possessedEntity as AnimateableEntity).CurrentFrameY = 2;
                (possessedEntity as AnimateableEntity)._velocity *= -1;
            }
            if ((possessedEntity as AnimateableEntity).Shape.Points[0].X >= startPos.X + 60)
            {
                (possessedEntity as AnimateableEntity).CurrentFrameY = 1;
                (possessedEntity as AnimateableEntity)._velocity *= -1;
            }

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
