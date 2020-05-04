using GameCode.Entites;
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
    public class GhostGuideMind : Mind
    {

        

        private Vector2 _velocity;

        private bool greetingCompleted;

        private int _count;

        public GhostGuideMind()
        {
            _velocity = new Vector2(1, -1);

            _count = 0;
        }

        public override void OnInputEvent(object source, EventArgs pArgs)
        {
            if (((OnInputEventArgs)pArgs)._keys.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                if(greetingCompleted)
                    _count++;

                if (_count == 1)
                {
                    (possessedEntity as SpeakingEntity).speechText = (possessedEntity as GhostlyGuid).pushBox;
                }
                if (_count == 2)
                {
                    (possessedEntity as SpeakingEntity).speechText = null;
                }
            }

            base.OnInputEvent(source, pArgs);
        }

        public override void Update(GameTime gameTime)
        {
            if (!greetingCompleted)
            {
                
                for (int i = 0; i < possessedEntity.Shape.Points.Count; i++)
                {
                    possessedEntity.Shape.Points[i] += _velocity;
                    if (possessedEntity.Shape.Points[i].X >= 140)
                    {
                        _velocity = new Vector2(0, -1);
                        (possessedEntity as SpeakingEntity).speechText = (possessedEntity as GhostlyGuid).wlcmeTxt;
                    }
                    if (possessedEntity.Shape.Points[i].Y <= 100)
                    {
                        greetingCompleted = true;
                    }
                }
                
            }

            base.Update(gameTime);
        }
    }
}
