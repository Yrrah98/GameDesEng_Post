using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Args
{
    public class OnInputEventArgs : EventArgs
    {

        public KeyboardState _keys;

        public OnInputEventArgs(KeyboardState args)
        {
            _keys = args;
        }
    }
}
