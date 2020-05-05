using GameCode.Entites.EnvironmentEntity;
using GameCode.Interfaces;
using GameEngine;
using GameEngine.Args;
using GameEngine.BaseMind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Minds
{
    class FloorBoxMind : Mind
    {

        public FloorBoxMind()
        {

        }

        public override void OnCollisionEvent(object source, EventArgs pArgs)
        {

            if (((OnCollisionEventArgs)pArgs).uids[0] == possessedEntity.UID || ((OnCollisionEventArgs)pArgs).uids[1] == possessedEntity.UID)
            {
                if (((OnCollisionEventArgs)pArgs).e1 is BoxEntity)
                {
                    foreach (StrategyDelegate d in (possessedEntity as IFloorPlate).doors)
                    {
                        d();
                    }
                }
                if (((OnCollisionEventArgs)pArgs).e2 is BoxEntity)
                {
                    foreach (StrategyDelegate d in (possessedEntity as IFloorPlate).doors)
                    {
                        d();
                    }
                }
            }
            base.OnCollisionEvent(source, pArgs);
        }
    }
}
