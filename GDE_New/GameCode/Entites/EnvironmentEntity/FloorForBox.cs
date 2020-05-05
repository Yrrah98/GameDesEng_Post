using GameCode.Interfaces;
using GameEngine;
using GameEngine.BaseEntity;
using GameEngine.Interfaces;
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
    class FloorForBox : StaticEntity, IFloorPlate
    {

        public IList<StrategyDelegate> doors { get; private set; } 

        public FloorForBox()
        {
            doors = new List<StrategyDelegate>();
        }

        public void SubscribeDoor(StrategyDelegate pDoorDel)
        {
            doors.Add(pDoorDel);
        }

        public override void Initialise(ContentManager pContent, String pUID)
        {
            // SET this entities texture
            //this.texture = pContent.Load<Texture2D>("");
            this.Texture = pContent.Load<Texture2D>("FloorForBox");

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
