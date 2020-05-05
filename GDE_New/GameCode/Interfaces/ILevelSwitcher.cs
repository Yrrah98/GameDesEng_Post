using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Interfaces
{
    public interface ILevelSwitcher
    {

        void InjectLevelSwitcher(StrategyDelegate pVoid);
    }
}
