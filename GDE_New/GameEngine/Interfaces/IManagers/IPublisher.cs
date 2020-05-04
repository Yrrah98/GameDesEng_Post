using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface IPublisher
    {


        void Subscribe(EventHandler<EventArgs> pEventHandler);

        void UnSubscribe(EventHandler<EventArgs> pEventHandler);
    }
}
