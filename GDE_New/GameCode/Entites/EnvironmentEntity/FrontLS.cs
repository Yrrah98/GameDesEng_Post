﻿using GameCode.Interfaces;
using GameEngine.BaseEntity;
using GameEngine.Shape;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Entites.EnvironmentEntity
{
    class FrontLS : AnimateableEntity, IDoor
    {

        public FrontLS()
        {

        }

        public void OpenThis()
        {
            if (this.Width > 0)
                this.Width -= 1;

            if (this.Width == 0)
                this.Remove = true;

        }

        public override void Initialise(ContentManager pContent, string pUID)
        {
            this.Texture = pContent.Load<Texture2D>("DoorFrontFacingLS");

            this.Height = 32;

            this.Width = 32;

            this.UID = pUID;
        }

        public override void SetPosition(Vector2 pPos)
        {
            this.Position = pPos;

            this.Shape = new Polygon();

            Shape.MakePoints(pPos);
        }
    }
}
