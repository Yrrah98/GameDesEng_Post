using GameCode.Entites.EnvironmentEntity;
using GameEngine.Args;
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
    class BoxMind : Mind
    {

        public BoxMind()
        {

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void OnCollisionEvent(object source, EventArgs pArgs)
        {

            if (possessedEntity.UID == ((OnCollisionEventArgs)pArgs).uids[0] || possessedEntity.UID == ((OnCollisionEventArgs)pArgs).uids[1])
            {
                for (int i = 0; i < possessedEntity.Shape.Points.Count; i++)
                {
                    //possessedEntity.Shape.Points[i] += ((OnCollisionEventArgs)pArgs)._mtv;
                    //if (((OnCollisionEventArgs)pArgs).e1 is AnimateableEntity)
                    //    possessedEntity.Shape.Points[i] += (((OnCollisionEventArgs)pArgs).e1 as AnimateableEntity)._velocity * 2;
                    //if (((OnCollisionEventArgs)pArgs).e2 is AnimateableEntity)
                    //    possessedEntity.Shape.Points[i] += (((OnCollisionEventArgs)pArgs).e2 as AnimateableEntity)._velocity * 2;
                }
                if (((OnCollisionEventArgs)pArgs).e1 is TopWall || ((OnCollisionEventArgs)pArgs).e2 is TopWall)
                {
                    for (int i = 0; i < possessedEntity.Shape.Points.Count; i++)
                    {
                        possessedEntity.Shape.Points[i] += ((OnCollisionEventArgs)pArgs)._mtv * 2;
                    }
                }
            }

            base.OnCollisionEvent(source, pArgs);
        }
    }
}
