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
    class LampEntity : StaticEntity
    {

        public LampEntity()
        {
            this.layerDepth = 0f;
        }

        public override void Initialise(ContentManager pContent, string pUID)
        {
            this.Texture = pContent.Load<Texture2D>("Lamp");

            this.UID = pUID;
        }

        public override void SetStaticPos(Vector2 pPos)
        {
            this.Position = pPos;

            this.Shape = new Polygon();

            Shape.MakePoints(pPos);
        }
    }
}
