using GameCode.Entites;
using GameCode.Entites.EnvironmentEntity;
using GameCode.Entites.Items;
using GameCode.Interfaces;
using GameCode.Minds;
using GameCode.Storage;
using GameEngine.BaseEntity;
using GameEngine.BaseItem;
using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCode.Levels
{
    public class Level2 : BaseLevel
    {
        private IEntity e;

        private IList<IEntity> floor;

        private IStorage _inventory;

        private int[,] map2;

        public Level2()
        {
            floor = new List<IEntity>();

        }

        public override void Initialise()
        {
            

            map2 = new int[,] {
                {0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,},
                {0, 2,  1,  1,  1,  1,  1,  1,  1,  2,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  1,  0,  1,  1,  1,  0,  1,  1,  1,  1,  1,  1,  1,  2,  1,  1,  1,  1,  1,  1,  1,  2,  1,  1,  0,},
                {0, 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,},
                {0, 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  0,  3,  3,  0,},
                {0, 3,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  3,  3,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  3,  3,  3,  3,  3,  3,  1,  0,  3,  3,  0,},
                {0, 3,  3,  0,  1,  1,  1,  1,  2,  1,  1,  1,  1,  1,  1,  1,  1,  1,  2,  1,  1,  1,  1,  1,  1,  1,  0,  3,  3,  3,  1,  2,  1,  1,  1,  1,  2,  1,  0,  3,  3,  3,  3,  3,  3,  3,  1,  3,  3,  0,},
                {0, 3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,},
                {0, 3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  0,  0,  0,  0,  3,  3,  3,  0,},
                {0, 3,  3,  0,  3,  3,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  3,  3,  3,  0,  3,  3,  0,  0,  0,  0,  3,  3,  3,  3,  3,  0,  3,  3,  3,  1,  2,  1,  0,  0,  3,  3,  0,},
                {0, 3,  3,  0,  3,  3,  3,  0,  1,  1,  1,  1,  1,  2,  1,  1,  1,  1,  2,  1,  1,  1,  0,  3,  3,  3,  0,  3,  3,  0,  1,  1,  0,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  3,  3,  1,  0,  3,  3,  0,},
                {0, 3,  3,  0,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  0,  3,  3,  0,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  0,},
                {0, 3,  3,  0,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  1,  3,  3,  1,  3,  3,  0,  3,  3,  0,  3,  3,  0,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  0,},
                {1, 3,  3,  2,  3,  3,  3,  0,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  3,  3,  3,  0,  0,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  2,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  0,},
                {3, 3,  5,  3,  3,  3,  3,  0,  0,  0,  1,  1,  1,  2,  1,  1,  1,  1,  0,  3,  3,  3,  1,  0,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  0,},
                {3, 3,  3,  3,  3,  3,  3,  1,  1,  1,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  0,  3,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  3,  3,  0,  0,  0,  0,  0,  0,  0,  0,},
                {3, 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  1,  3,  3,  3,  3,  0,  0,  0,  0,  0,  0,  0,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  0,  0,  0,  1,  1,  2,  1,  1,  1,  0,},
                {0, 3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  1,  1,  1,  2,  1,  1,  1,  3,  3,  0,  3,  3,  0,  0,  0,  0,  0,  0,  1,  1,  3,  3,  3,  3,  3,  3,  1,},
                {0, 3,  3,  0,  3,  3,  3,  3,  3,  0,  0,  0,  0,  0,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  1,  1,  1,  2,  1,  1,  3,  3,  3,  3,  3,  3,  3,  3,  3,},
                {0, 3,  3,  0,  3,  3,  3,  3,  3,  0,  1,  2,  1,  1,  0,  3,  3,  0,  3,  3,  3,  3,  3,  0,  0,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,},
                {0, 3,  3,  0,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  3,  2,  1,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,},
                {0, 3,  3,  0,  0,  0,  0,  0,  0,  0,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  3,  3,  3,  0,  0,  0,  0,  0,  3,  3,  0,  0,  0,  0,},
                {0, 3,  3,  1,  1,  2,  1,  1,  1,  1,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  3,  0,  0,  0,  0,  3,  3,  0,  0,  0,  0,  0,  0,  0,  0,  3,  3,  3,  3,  0,  1,  2,  1,  0,  3,  3,  0,  1,  1,  0,},
                {0, 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  3,  1,  2,  1,  1,  3,  3,  1,  1,  1,  0,  1,  1,  1,  0,  0,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  0,  3,  3,  0,},
                {0, 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  0,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,  3,  3,  3,  1,  0,  3,  3,  3,  0,  3,  3,  3,  0,  3,  3,  0,  3,  3,  0,},
                {0, 3,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  3,  3,  0,  0,  0,  0,  0,  0,  0,  0,  3,  3,  0,  0,  0,  0,  3,  3,  3,  3,  0,  0,  0,  0,  0,  3,  3,  3,  0,  0,  0,  0,  3,  3,  0,},
                {0, 3,  3,  1,  1,  2,  1,  1,  1,  1,  1,  2,  1,  1,  1,  3,  3,  1,  1,  2,  1,  2,  1,  1,  1,  3,  3,  1,  2,  1,  1,  3,  3,  3,  3,  1,  1,  2,  1,  1,  3,  3,  3,  1,  1,  2,  1,  3,  3,  0,},
                {0, 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,},
                {0, 3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  0,},
                {0, 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,}

            };
        }



        public override void Update(GameTime gameTime)
        {
            (_sceneManager as IUpdate).Update(gameTime);
            (_mindManager as IUpdate).Update(gameTime);
            (_inputManager as IUpdate).Update(gameTime);
            (_collisionManager as IUpdate).Update(gameTime);



            base.Update(gameTime);
        }

        public override void PassMngers()
        {
            (this.NextLevel as IManagerInject).InjectManagers(_entityManager, _collisionManager, _inputManager, _sceneManager, _mindManager, _contentManager);
        }

        private void GenerateMap(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    IMind m;

                    switch (number)
                    {
                        case 0:
                            e = _entityManager.CreateEntity<TopWall>(_contentManager);
                            break;
                        case 1:
                            e = _entityManager.CreateEntity<Wall>(_contentManager);
                            break;
                        case 2:
                            e = _entityManager.CreateEntity<LampEntity>(_contentManager);
                            break;
                        case 3:
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 4:
                            e = _entityManager.CreateEntity<BoxEntity>(_contentManager);
                            m = _mindManager.CreateMind<BoxMind>(e);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            (_collisionManager as IPublisher).Subscribe((m as ICollisionListener).OnCollisionEvent);
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 5:
                            e = _entityManager.CreateEntity<PlayerEntity>(_contentManager);
                            m = _mindManager.CreateMind<PlayerMind>(e);
                            (m as IStorer).Inject(_sceneManager.RemoveFromScene);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            _inventory = new Inventory();
                            (e as PlayerEntity).GiveInventory(_inventory);
                            _inputManager.Subscribe((m as IInputListener).OnInputEvent);
                            (_collisionManager as IPublisher).Subscribe((m as ICollisionListener).OnCollisionEvent);
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 6:
                            e = _entityManager.CreateEntity<GhostlyGuid>(_contentManager);
                            m = _mindManager.CreateMind<GhostGuideMind>(e);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            _inputManager.Subscribe((m as IInputListener).OnInputEvent);
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 7:
                            e = _entityManager.CreateEntity<BoneSawEntity>(_contentManager);
                            m = _mindManager.CreateMind<BoneSawMind>(e);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            (_collisionManager as IPublisher).Subscribe((m as ICollisionListener).OnCollisionEvent);
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 8:
                            e = _entityManager.CreateEntity<LeechEntity>(_contentManager);
                            m = _mindManager.CreateMind<LeechMind>(e);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            (_collisionManager as IPublisher).Subscribe((m as ICollisionListener).OnCollisionEvent);
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 9:
                            e = _entityManager.CreateEntity<Syringe>(_contentManager);
                            m = _mindManager.CreateMind<SyringeMind>(e);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            (_collisionManager as IPublisher).Subscribe((m as ICollisionListener).OnCollisionEvent);
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 10:
                            e = _entityManager.CreateEntity<Enemy1>(_contentManager);
                            m = _mindManager.CreateMind<Enemy1Mind>(e);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                        case 11:
                            e = _entityManager.CreateEntity<Enemy2>(_contentManager);
                            m = _mindManager.CreateMind<Enemy2Mind>(e);
                            AddAnimateable(e, new Vector2(x * size, y * size));
                            e = _entityManager.CreateEntity<FloorEntity>(_contentManager);
                            break;
                    }

                    if (e is StaticEntity)
                        (e as StaticEntity).SetStaticPos(new Vector2(x * size, y * size));
                    if (e is FloorEntity)
                    {
                        floor.Add(e);
                    }
                    else
                        _sceneManager.AddEntityWorld(e);

                }
        }

        private void AddAnimateable(IEntity e, Vector2 pos)
        {
            (e as AnimateableEntity).SetPosition(pos);

            _sceneManager.AddEntityWorld(e);
        }

        #region Inherited Methods

        public override void UnloadContent()
        {

        }

        /// <summary>
        /// METHOD: LoadContent, a method which Loads the content of the levels
        /// </summary>
        public override void LoadContent()
        {

            GenerateMap(map2, 32);

            _inventory.SetupStorage(_contentManager);


            /*
             * UP TO HERE - ADD ENTITY POSITION
             * ADD ENTITY SHAPE AND EDIT POINTS
             */
        }

        /// <summary>
        /// METHOD:
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <returns></returns>
        public override SpriteBatch Draw(SpriteBatch spriteBatch)
        {

            foreach (StaticEntity e in floor)
            {
                spriteBatch.Draw(e.Texture, new Rectangle((int)e.Position.X, (int)e.Position.Y, 32, 32), Color.AntiqueWhite);
            }


            _sceneManager.Draw(spriteBatch);
            spriteBatch.Draw(_inventory.BgTxtr, new Rectangle((int)(_inventory as Inventory).Position.X, (int)(_inventory as Inventory).Position.Y, 256, 32), Color.AntiqueWhite);
            if (_inventory.ItemCollection != null)
            {
                foreach (KeyValuePair<String, BaseItem> b in _inventory.ItemCollection)
                {
                    spriteBatch.Draw(b.Value.Texture,
                        new Rectangle((int)_inventory.CollectionPositions[b.Key].X, (int)_inventory.CollectionPositions[b.Key].Y, b.Value.Width, b.Value.Height),
                        new Rectangle(b.Value.Width * b.Value.CurrentFrameX,
                        b.Value.Height * b.Value.CurrentFrameY, b.Value.Width, b.Value.Height), Color.AntiqueWhite);
                }
            }


            return spriteBatch;
        }

        #endregion
    }
}
