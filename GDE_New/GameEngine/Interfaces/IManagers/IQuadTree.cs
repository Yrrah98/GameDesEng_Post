using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface IQuadTree<T> where T : IShape
    {

        void NodeCollisions();

        void AddEntity(IList<IEntity> e);

        void Clear();

        void SubDivide();

        int NodeLevel { get; }

        IList<IEntity> Entities { get; set; }

        Rectangle NodeRectangle { get; set; }

        void SetDelegate(CheckEntityCollisions pCheckCollisions);
    }
}
