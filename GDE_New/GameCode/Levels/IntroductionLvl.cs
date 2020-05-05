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
    public class IntroductionLvl : BaseLevel
    {

        private Texture2D IntroText { get; set; }

        private Texture2D IntroText2 { get; set; }

        private Texture2D PressSpace { get; set; }

        public Rectangle Area { get; set; }

        private int _pulseAlpha = 0;

        private bool complete = false;

        private int _pulseAdjstr = 3;

        private bool first = false;

        private int _switcher = 0;

        public IntroductionLvl()
        {

        }

        #region Private methods
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

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (_switcher >= 100)
                    SwitchLevel = true;

                IntroText = IntroText2;
                first = true;
            }

            if (first)
                _switcher++;

            base.Update(gameTime);
        }

        public override void Initialise()
        {
            this.NextLevel = new Level1();

            IntroText = _contentManager.Load<Texture2D>("IntroTxt1");

            IntroText2 = _contentManager.Load<Texture2D>("IntroTxt2");

            PressSpace = _contentManager.Load<Texture2D>("PressSpaceWhite");
        }

        public override void LoadContent()
        {
            
        }

        public override void PassMngers()
        {
            (this.NextLevel as IManagerInject).InjectManagers(_entityManager, _collisionManager, _inputManager, _sceneManager, _mindManager, _contentManager);
        }

        public override void Unload()
        {
            
        }

        public override SpriteBatch Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(IntroText, Area, Color.White);

            spriteBatch.Draw(PressSpace, new Rectangle(600, 800, PressSpace.Width, PressSpace.Height), PulseStart(Color.White));

            return spriteBatch;
        }
    }
}
