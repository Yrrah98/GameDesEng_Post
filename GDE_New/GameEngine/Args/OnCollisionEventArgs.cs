using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Args
{
    public class OnCollisionEventArgs : EventArgs
    {
        public IEntity e1;

        public IEntity e2;

        public Vector2 _mtv;

        public string[] uids;

        public OnCollisionEventArgs(IEntity _e1, IEntity _e2, Vector2 pMTV)
        {

            uids = new String[2];

            _mtv = pMTV;

            e1 = _e1;

            if (_e2 != null)
            {
                e2 = _e2;

                uids[1] = e2.UID;
            }

            uids[0] = e1.UID;


        }
    }
}
