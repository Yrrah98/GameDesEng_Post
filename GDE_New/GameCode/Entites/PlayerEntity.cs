using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.BaseEntity;
using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Reflection;
using GameEngine.Shape;
using GameCode.Interfaces;
using GameCode.Storage;

namespace GameCode.Entites
{
    public class PlayerEntity : AnimateableEntity
    {

        public IStorage _inventory;

        /// <summary>
        /// CONSTRUCTOR: With a call to the base class passing in a string from the constructor parameters
        /// </summary>
        /// <param name="pUID"></param>
        public PlayerEntity()
        {
            this._velocity = new Vector2(4, 4);
        }

        public void GiveInventory(IStorage pInv)
        {
            _inventory = pInv;
        }

        public override void Initialise(ContentManager pContent, String pUID)
        {
            // SET this entities texture
            this.Texture = pContent.Load<Texture2D>("InfirmChar");

            _inventory = new Inventory();

            _inventory.SetupStorage(pContent);

            this.switchFrame = 100;

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
