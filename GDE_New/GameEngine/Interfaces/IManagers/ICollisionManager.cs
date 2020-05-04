using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface ICollisionManager
    {

        IQuadTree<IShape> QuadTree { get; }

        void CheckEntityCollisions(IEntity e1, IEntity e2);

    }
}
