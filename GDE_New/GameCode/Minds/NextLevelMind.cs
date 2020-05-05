using GameCode.Entites;
using GameCode.Entites.EnvironmentEntity;
using GameCode.Entites.Items;
using GameCode.Interfaces;
using GameEngine;
using GameEngine.Args;
using GameEngine.BaseEntity;
using GameEngine.BaseItem;
using GameEngine.BaseMind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Minds
{
    public class NextLevelMind : Mind, ILevelSwitcher
    {

        private StrategyDelegate _switch;

        public NextLevelMind()
        {

        }

        public void InjectLevelSwitcher(StrategyDelegate pVoid)
        {
            _switch = pVoid;
        }

        public override void OnCollisionEvent(object source, EventArgs pArgs)
        {


            if (((OnCollisionEventArgs)pArgs).uids[0] == possessedEntity.UID || ((OnCollisionEventArgs)pArgs).uids[1] == possessedEntity.UID)
            {
                if (((OnCollisionEventArgs)pArgs).e1 is PlayerEntity)
                {
                    foreach (KeyValuePair<String, BaseItem> v in (((OnCollisionEventArgs)pArgs).e1 as PlayerEntity)._inventory.ItemCollection)
                    {
                        if (v.Value is Syringe)
                        {
                            _switch();
                        }
                    }
                }

                if (((OnCollisionEventArgs)pArgs).e2 is PlayerEntity)
                {
                    foreach (KeyValuePair<String, BaseItem> v in (((OnCollisionEventArgs)pArgs).e2 as PlayerEntity)._inventory.ItemCollection)
                    {
                        if (v.Value is Syringe)
                        {
                            _switch();
                        }
                    }
                }
            }

        }

    }
}
