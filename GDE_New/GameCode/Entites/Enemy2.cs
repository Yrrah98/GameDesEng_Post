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

namespace GameCode.Entites
{
    class Enemy2 : AnimateableEntity
    {


        public Enemy2()
        {
            this._velocity = new Vector2(2, 0);
        }

        public override void Initialise(ContentManager pContent, String pUID)
        {
            // SET this entities texture
            this.Texture = pContent.Load<Texture2D>("Enemy");

            this.CurrentFrameY = 2;

            this.active = true;

            this.switchFrame = 160;

            this.Height = 32;

            this.Width = 32;

            this.maxWidth = 4;

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
