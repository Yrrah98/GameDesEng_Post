﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Interfaces
{
    interface IUpdateableComp
    {
        void Update(GameTime gameTime);
    }
}
