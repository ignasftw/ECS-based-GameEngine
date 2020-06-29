using System;
using System.Collections.Generic;
using ECSGame.Component.Physics.RigidBodies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECSEngine.Inputs;
using ECSEngine.Component.Rendering;
using ECSGame.Systems.ColiderSystem;

namespace ECSGame
{
    public class Game1 : Game
    {
        //DECLARE a GraphicsDeviceManager call it '_graphics'
        private GraphicsDeviceManager _graphics;
        //DECLARE a SpriteBatch which is required for sprite rendering, call it '_spriteBatch'
        private SpriteBatch _spriteBatch;
        private List<ECSEngine.IUpdatable> _updateable;
        //DECLARE a IInputPublisher which announced when spacebar is pressed, call it '_spaceBarHandler'
        private IInputPublisher _spaceBarHandler;
        //DECLARE a CollisionSystem which will collisions in the simulation, call it '_collisionSystem'
        private ICollisionSystem _collisionSystem;
        //DECLARE a Scene which will tell the current scene, call it '_curScene'
        private ECSEngine.Scene.Scene _curScene;

        private ECSEngine.SceneManager _sceneManager;

        private int ScreenWidth;
        private int ScreenHeight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Set the Sceen's Height dimensions in pixels
            ScreenHeight = GraphicsDevice.Viewport.Height;
            //Set the Sceen's Width dimensions in pixels
            ScreenWidth = GraphicsDevice.Viewport.Width;
            //Initialize SceneManager
            _sceneManager = new ECSEngine.SceneManager();
            //Initialize InputManager
            _spaceBarHandler = new KeyboardInputHandler();
            //Initialize Collision System
            _collisionSystem = new CollisionSystem();

            //Initialize empty list of IUpdatables
            _updateable = new List<ECSEngine.IUpdatable>();

            //Initialize and store a test scene
            Scenes.TestScene testScene = new Scenes.TestScene(_collisionSystem.AddCollider, Content, ScreenWidth, ScreenHeight);
            _spaceBarHandler.Subscribe(testScene);
            _sceneManager.AddScene("TestScene", testScene);
            //Set the initial Scene
            _curScene = _sceneManager.SetScene("TestScene");
            //Add all the updatables into a list, this is not done into a dictionary earlier to avoid confusion
            //and messy code
            _updateable.Add(_curScene as ECSEngine.IUpdatable);
            _updateable.Add(_spaceBarHandler as ECSEngine.IUpdatable);
            _updateable.Add(_collisionSystem as ECSEngine.IUpdatable);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //IF the player presses 'Escape' button then terminate the simulation
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //If the entity count exceeds 200, then switch the scenes
            if (_curScene._entities.Count > Scenes.TestScene.WarriorAmount+50)
            {
                //Unsubscribe the spacebar event to prevent bullet spawning
                _spaceBarHandler.Unsubscribe(_curScene as IInputListener);
                //Add a new TestEndScene 
                _sceneManager.AddScene("TestEndScene", new Scenes.TestEndScene(Content));
                //Set the current scene to "TestEndScene" because the demo ended
                _curScene = _sceneManager.SetScene("TestEndScene");
            }

            foreach (ECSEngine.IUpdatable system in _updateable)
            {
                system.Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Set default blank screen colour
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Start spriteBatch for drawing sprites
            _spriteBatch.Begin();
            //Draw all the Draw compoenets
            ECSEngine.Rendering.Renderer.Draw(_spriteBatch);
            //Stop spriteBatch after everything is drawn
            _spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
