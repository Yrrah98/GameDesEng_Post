using GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{

    public delegate IList<IEntity> SceneEntitiesDelegate();

    public delegate void CheckEntityCollisions(IEntity e1, IEntity e2);

    public delegate void StrategyDelegate();

    public delegate void StoreItemDelegate(IEntity e);
}
