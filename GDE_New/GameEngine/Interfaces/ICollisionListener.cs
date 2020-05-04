using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface ICollisionListener
    {

        void OnCollisionEvent(object source, EventArgs pArgs);
    }
}
