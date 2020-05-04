using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    public interface ILevel
    {
        ILevel NextLevel { get; }

        bool SwitchLevel { get; }

        void PassMngers();

        void Initialise();

        void LoadContent();

        SpriteBatch Draw(SpriteBatch spriteBatch);
    }
}
