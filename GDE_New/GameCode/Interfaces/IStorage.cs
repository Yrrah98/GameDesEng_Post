using GameEngine.BaseItem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Interfaces
{
    public interface IStorage
    {
        IDictionary<String, BaseItem> ItemCollection { get; }

        IDictionary<String, Vector2> CollectionPositions { get; }

        int[,] Size { get; }

        Texture2D BgTxtr { get; set; }

        void AddItem(BaseItem pItem);

        void SetupStorage(ContentManager pContentManager);
    }
}
