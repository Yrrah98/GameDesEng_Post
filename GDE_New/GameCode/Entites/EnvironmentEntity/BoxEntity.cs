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
    class BoxEntity : AnimateableEntity
    {

        public BoxEntity()
        {

        }

        public void PushBox(Vector2 velocity)
        {
            for (int i = 0; i < this.Shape.Points.Count; i++)
            {
                Shape.Points[i] += velocity * 2;
            }
        }


        public override void Initialise(ContentManager pContent, String pUID)
        {
            // SET this entities texture
            //this.texture = pContent.Load<Texture2D>("");
            this.Texture = pContent.Load<Texture2D>("BoxMoveable");

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
