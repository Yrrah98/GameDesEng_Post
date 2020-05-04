using GameCode.Levels;
using GameEngine.Interfaces;
using GameEngine.Interfaces.IManagers;
using GameEngine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GDE_New
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // DECLARE an ILevel called _levelX - to store the current level
        private ILevel _levelX;
        // DECLARE an IEntityManager called _entityMgr
        private IEntityManager _entityMgr;
        // DECLARE an ISceneManager called _sceneMgr
        private ISceneManager _sceneMgr;
        // DECLARE an ICollisionManger called _collisionMgr
        private ICollisionManager _collisionMgr;
        // DECLARE an IMindManager called _mindMgr
        private IMindManager _mindMgr;
        // DECLARE an IPublisher called _inputMgr
        private IPublisher _inputMgr;

        private bool _paused { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //graphics.PreferredBackBufferHeight = 450;
            //graphics.PreferredBackBufferWidth = 800;

            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // INITIALISE the EntityManager variable
            _entityMgr = new EntityManager();
            // INITIALISE the SceneManager variable
            _sceneMgr = new SceneManager();
            // INITIALISE the CollisionManager variable
            // PASSING IN reference to the SceneMgr.SceneEntitiesDelegate method
            // as well a new QuadTree whos position is set to 0,0 and width and height is the screen width and height
            _collisionMgr = new CollisionManager(_sceneMgr.SceneEntitiesDelegate, _sceneMgr.StaticEntitiesDelegate,
                new QuadTree<IShape>(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                1));
            // INITIALISE the MindManager variable
            _mindMgr = new MindManager();
            // INITIALISE the InputManager variable
            _inputMgr = new InputManager(PauseGameState);
            // INITIALISE the level to the first level
            // FUTURE IMPROVEMENT ------ possibly in the future make the level selectable
            _levelX = new SplashScreen();
            // CALL to InjectManagers into the level selected
            (_levelX as IManagerInject).InjectManagers(_entityMgr, _collisionMgr,
                _inputMgr, _sceneMgr, _mindMgr, Content);

            (_levelX as SplashScreen).TitleArea = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            // CALL to Initialise the current level
            _levelX.Initialise();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // CALL to LoadContent method of current level
            _levelX.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private void PauseGameState()
        {
            _paused = !_paused;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            //if (Keyboard.GetState().IsKeyDown(Keys.P))
            //    PauseGameState();

            if (_levelX.SwitchLevel)
            {
                _levelX.PassMngers();

                _levelX = _levelX.NextLevel;

                _levelX.Initialise();

                _levelX.LoadContent();
            }
            else if (!_paused)
                (_levelX as IUpdate).Update(gameTime);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            // DRAW the level
            spriteBatch.Begin();
            _levelX.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
