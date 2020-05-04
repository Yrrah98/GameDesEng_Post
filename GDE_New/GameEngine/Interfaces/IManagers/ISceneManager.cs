using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces.IManagers
{
    public interface ISceneManager
    {
        void AddEntityWorld(IEntity e);

        void RemoveEntityFromWorld(IEntity e);

        IList<IEntity> SceneEntitiesDelegate();

        IList<IEntity> StaticEntitiesDelegate();

        IList<IEntity> SceneMgrEList { get; set; }

        IEntity EToRemove { get; set; }

        void RemoveFromScene(IEntity e);

        SpriteBatch Draw(SpriteBatch spriteBatch);

        void NextLevelStart();
    }
}
