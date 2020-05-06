using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Interfaces
{
    public interface IFloorPlate
    {
        IList<StrategyDelegate> doors { get; }

        IList<StrategyDelegate> openDoors { get; }

        void SubscribeDoor(StrategyDelegate pDoorDel);

        void SubscribeClose(StrategyDelegate pCloseDoor);
    }
}
