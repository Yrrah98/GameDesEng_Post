using GameEngine.Args;
using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Managers
{
    public class InputManager : IPublisher, IUpdate
    {
        // DECLARE an EventHandler of type EventArgs called OnInputEvent
        private EventHandler<EventArgs> OnInputEvent;
        // DECLARE a KeyboardState called __newInput to store new inputs
        private KeyboardState _newInput;
        // DECLARE a KeyboardState called __oldInput to store the old input to check
        // the new input against it
        private KeyboardState _oldInput;

        private StrategyDelegate _pauseUnpause;

        /// <summary>
        /// CONSTRUCTOR for InputManager
        /// </summary>
        public InputManager(StrategyDelegate pPauseG)
        {
            _pauseUnpause = pPauseG;
        }


        #region IUpdateableComp
        public void Update(GameTime gameTime)
        {
            // SET _newInput to the current keyboard state using
            // Keyboard.GetState method
            _newInput = Keyboard.GetState();

            //if (_newInput.IsKeyDown(Keys.P))
            //{
            //    _pauseUnpause();
            //}

            // IF the _oldInput is not equal to the _newInput
            if (_oldInput != _newInput)
            {
                // SET _oldInput to the newInput
                _oldInput = _newInput;
                // DECLARE a new OnInputEventArgs called args
                // SET as new OnInputEventArgs passing in the input as a parameter
                OnInputEventArgs args = new OnInputEventArgs(_oldInput);
                // CALL to notifyListners method, passing in the args
                notifyListners(args);
            }
        }
        #endregion

        #region Private
        private void notifyListners(EventArgs args)
        {
            OnInputEvent(this, args);
        }
        #endregion


        #region IPublisher
        public void Subscribe(EventHandler<EventArgs> pEventHandler) 
        {
            OnInputEvent += pEventHandler;
        }

        public void UnSubscribe(EventHandler<EventArgs> pEventHandler)
        {
            OnInputEvent -= pEventHandler;
        }

        #endregion
    }
}
