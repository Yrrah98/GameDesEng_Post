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
    public class GhostlyGuid : SpeakingEntity
    {

        public bool activateTex { get; set; }

        public Texture2D wlcmeTxt { get; set; }

        public Texture2D pushBox { get; set; }
        
        public Texture2D enemiesTxt { get; set; }

        public Texture2D itemsTxt { get; set; }

        public GhostlyGuid()
        {
        }

        public override void Initialise(ContentManager pContent, String pUID)
        {
            // SET this entities texture
            //this.texture = pContent.Load<Texture2D>("");
            this.Texture = pContent.Load<Texture2D>("GhostlyGuide");

            this.wlcmeTxt = pContent.Load<Texture2D>("FirstTxtBox");

            this.pushBox = pContent.Load<Texture2D>("PushBoxText");

            this.enemiesTxt = pContent.Load<Texture2D>("EnemiesTxt");

            this.itemsTxt = pContent.Load<Texture2D>("ItemsTxt");

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
