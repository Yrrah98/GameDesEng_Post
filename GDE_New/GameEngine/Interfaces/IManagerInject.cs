using GameEngine.Interfaces.IManagers;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface IManagerInject
    {

        void InjectManagers(IEntityManager pEM, ICollisionManager pCM, 
            IPublisher pIM, ISceneManager pSM, IMindManager pMM, ContentManager pCntnt);
    }
}
