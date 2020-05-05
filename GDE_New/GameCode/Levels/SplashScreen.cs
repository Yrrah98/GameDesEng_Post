using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Levels
{
    public class SplashScreen : BaseLevel, IUpdate
    {

        private Texture2D TitleTexture { get; set; }

        public Rectangle TitleArea { get; set; }

        private bool complete;

        #region FadeInFadeOut variables

        private int _txtrAlpha = 0;

        private int _txtrAdjster = 3;

        private bool transitionEnded = false;


        #endregion

        public SplashScreen()
        {
            NextLevel = new TitleScreenLevel();
        }

        #region Private Methods
        private Color FadeTexture(Color pBase)
        {
            _txtrAlpha += _txtrAdjster;

            if (_txtrAlpha == 255)
            {
                _txtrAdjster = -1;

                complete = true;
            }

            if (complete)
                if (_txtrAlpha <= 0)
                {
                    this.SwitchLevel = true;
                    Unload();
                }

            Color c = new Color(_txtrAlpha, _txtrAlpha, _txtrAlpha, _txtrAlpha);

            return c;
        }
        #endregion

        #region Inherited Methods
        public override SpriteBatch Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TitleTexture, TitleArea, FadeTexture(Color.Black));

            return spriteBatch;
        }

        public override void Unload()
        {
            TitleTexture.Dispose();
        }

        public override void Initialise()
        {
            NextLevel = new TitleScreenLevel();

            this.TitleTexture = _contentManager.Load<Texture2D>("SplashScreen");
        }

        public override void PassMngers()
        {
            (NextLevel as TitleScreenLevel).TitleArea = this.TitleArea;

            (this.NextLevel as IManagerInject).InjectManagers(_entityManager, _collisionManager, _inputManager, _sceneManager, _mindManager, _contentManager);
        }

        public override void LoadContent()
        {
        }

        #endregion

    }
}
