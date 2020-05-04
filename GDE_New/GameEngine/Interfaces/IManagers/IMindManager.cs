using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface IMindManager
    {

        IMind CreateMind<T>(IEntity e) where T : IMind, new();

        IList<IMind> MindList { get; set; }

        IMind MindsToRemove { get; set; }
    }
}
