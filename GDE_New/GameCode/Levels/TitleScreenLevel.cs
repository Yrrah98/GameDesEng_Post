using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameCode.Levels
{
    public class TitleScreenLevel : BaseLevel, IUpdate
    {

        private Texture2D TitleTexture { get; set; }

        private Texture2D PressStart { get; set; }

        public Rectangle TitleArea { get; set; }

        private ILevel _nextLevel;

        #region FadeInFadeOut variables

        private int _txtrAlpha = 255;

        private int _pulseAlpha = 0;

        private bool complete = false;

        private int _pulseAdjstr = 3;

        private int _txtrAdjster = -1;

        private bool startTransition = false;


        #endregion

        /// <summary>
        /// 
        /// </summary>
        public TitleScreenLevel()
        {
            NextLevel = new Level1();
        }


        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _pulseAlpha = 255;

                startTransition = true;
            }

        }

        #region Private Methods
        private Color FadeTexture(Color pBase)
        {
            

            _txtrAlpha += _txtrAdjster;

            if (_txtrAlpha <= 0)
            {
                SwitchLevel = true;
                Unload();
            }

            

            Color c = new Color(_txtrAlpha, _txtrAlpha, _txtrAlpha, _txtrAlpha);

            return c;
        }

        private Color PulseStart(Color pColor)
        {
            _pulseAlpha += _pulseAdjstr;

            if (_pulseAlpha >= 255)
            {
                _pulseAdjstr *= -1;

                complete = true;
            }

            if (complete)
                if (_pulseAlpha <= 0)
                {
                    _pulseAdjstr *= -1;
                    complete = !complete;
                }

            Color n = new Color(_pulseAlpha, _pulseAlpha, _pulseAlpha, _pulseAlpha);

            return n;

        }
        #endregion

        #region Inherited Methods
        public override void Unload()
        {
            TitleTexture.Dispose();
        }

        public override SpriteBatch Draw(SpriteBatch spriteBatch)
        {
            

            if (!startTransition)
                spriteBatch.Draw(TitleTexture, TitleArea, Color.AntiqueWhite);
            else
                spriteBatch.Draw(TitleTexture, TitleArea, FadeTexture(Color.AntiqueWhite));

            spriteBatch.Draw(PressStart, new Rectangle(600, 650, PressStart.Width, PressStart.Height), PulseStart(Color.AntiqueWhite));

            return spriteBatch;
        }

        public override void PassMngers()
        {
            (this.NextLevel as IntroductionLvl).Area = this.TitleArea;

            (this.NextLevel as IManagerInject).InjectManagers(_entityManager, _collisionManager, _inputManager, _sceneManager, _mindManager, _contentManager);
        }

        public override void Initialise()
        {
            NextLevel = new IntroductionLvl();

            this.TitleTexture = _contentManager.Load<Texture2D>("TitleScreen");

            this.PressStart = _contentManager.Load<Texture2D>("PressSpace");
        }

        public override void LoadContent()
        {
        }

        #endregion
    }
}
