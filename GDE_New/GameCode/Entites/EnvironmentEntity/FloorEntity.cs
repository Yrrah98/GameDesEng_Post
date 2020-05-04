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
    public class FloorEntity : StaticEntity
    {

        public FloorEntity()
        {
            this.layerDepth = 0;
        }

        public override void Initialise(ContentManager pContent, string pUID)
        {
            this.Texture = pContent.Load<Texture2D>("Floor");

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
