using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.BaseEntity;
using Microsoft.Xna.Framework.Audio;
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
    public class PlayerEntity : KillableEntity
    {

        public IStorage _inventory;

        public int Lives { get; set; }

        /// <summary>
        /// CONSTRUCTOR: With a call to the base class passing in a string from the constructor parameters
        /// </summary>
        /// <param name="pUID"></param>
        public PlayerEntity()
        {
            this._velocity = new Vector2(4, 4);

            Lives = 100;
        }

        public void GiveInventory(IStorage pInv)
        {
            _inventory = pInv;
        }

        public override void Initialise(ContentManager pContent, String pUID)
        {
            // SET this entities texture
            this.Texture = pContent.Load<Texture2D>("InfirmChar");
            // SET the sound effect for this entities movement
            this.eSfx = pContent.Load<SoundEffect>("Running");
            // SET the GreenTxtr and RedTxtr textures for the hp bar
            this.GreenTxtr = pContent.Load<Texture2D>("HpBarG");
            this.RedTxtr = pContent.Load<Texture2D>("HpBarR");
            // SET the Position of the HP bar to the top left of the screen
            this._hpPos = new Vector2(16, 16);
            // SET the _hpWidthMax to 256
            this._hpWidthMax = 256;
            // SET the current hp val to the max width -- start on full hp
            this._hpWidthCurr = this._hpWidthMax;
            // SET the rectangle of the green hp bar
            this._hpAreaG = new Rectangle((int)_hpPos.X, (int)_hpPos.Y, _hpWidthCurr, 16);
            // SET the rectangle of the red part of hp bar
            this._hpAreaR = new Rectangle((int)_hpPos.X + _hpAreaG.Width, (int)_hpPos.Y, _hpWidthMax - _hpWidthCurr, 16);
            // INSTANTIATE a new inventory
            _inventory = new Inventory();
            // CALL inventory SetupStorage method, passing in the content manage
            _inventory.SetupStorage(pContent);
            // SET the SwitchFrame rate of the entity
            this.switchFrame = 100;
            // SET the height and width of the entity to 32
            this.Height = 32;
            this.Width = 32;
            // SET the maxWidth for the frames to 4
            this.maxWidth = 4;
            // SET the UID of the entity
            this.UID = pUID;
        }

        /// <summary>
        /// METHOD: Take Damage, a method which causes the entity to take damage equal to a value passed in
        /// </summary>
        /// <param name="pDmg"></param>
        public override void TakeDamage(int pDmg)
        {
            _hpWidthCurr -= pDmg;
        }

        public override void SetPosition(Vector2 pPos)
        {
            this.Position = pPos;

            this.Shape = new Polygon();

            Shape.MakePoints(pPos);
        }
    }
}
