using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface ISceneGraph
    {

        IList<IEntity> InSceneList { get; set; }

        IList<IEntity> StaticEntities { get; set; }

        void AddSceneList(IEntity e);

        void RemoveSceneList(IEntity e);

        IList<IEntity> SceneEntitiesDelegate();

        IList<IEntity> StaticEntitiesDelegate();
    }
}
