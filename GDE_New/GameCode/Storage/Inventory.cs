using GameCode.Interfaces;
using GameEngine.BaseEntity;
using GameEngine.BaseItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Storage
{
    class Inventory : IStorage
    {

        public Texture2D BgTxtr { get; set; }

        private IDictionary<String, BaseItem> _itemCollection;

        public IDictionary<String, BaseItem> ItemCollection { get { return _itemCollection; } }

        public IDictionary<String, Vector2> CollectionPositions { get; set; }

        public int[,] Size { get; private set; }

        public Vector2 Position;

        private bool added = false;

        private int xIncr = 0;

        private int xIncr2 = 0;

        private int yIncr = 0;

        public Inventory()
        {
            _itemCollection = new Dictionary<String, BaseItem>();

            CollectionPositions = new Dictionary<String, Vector2>();

            Position = new Vector2(1200, 0);
        }

        public void AddItem(BaseItem pItem)
        {
            for (int x = 0; x < Size.GetLength(1); x++)
            {
                for (int y = 0; y < Size.GetLength(0); y++)
                {
                    if (_itemCollection.Count < 8)
                    {
                        if (!added)
                        {
                            added = true;

                            String guid = Guid.NewGuid().ToString();

                            Vector2 v = new Vector2(Position.X + x + xIncr * 32, Position.Y + y * 32);

                            CollectionPositions.Add(guid, v);

                            _itemCollection.Add(guid, pItem);

                            if (xIncr < 8)
                            {
                                xIncr += 1;
                                
                            }

                            //if (xIncr == 8)
                            //{
                            //    xIncr = 0;
                            //    yIncr += 1;
                            //}
                            //if (xIncr == 3 && yIncr < 0)
                            //{
                            //    xIncr = 0;
                            //    yIncr += 1;
                            //}


                        }
                    }
                    

                }

            }

            added = false;
        }

        public void SetupStorage(ContentManager pContentManager)
        {

            /*
             * 
             * UP TO HERE 26/04/2020: 
             * Display inventory bottom middle right 
             * Add inventory as an entity?? pass a delegate to let
             * an entity add items to it
             * Add some kind of bool to say whether to display an entity or not
             * bool _display an display if true, if "I" is pressed, set inventory 
             * show bool to true;
             * 
             */

            BgTxtr = pContentManager.Load<Texture2D>("InventoryLong");

            Size = new int[,] {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
        }
    }
}
