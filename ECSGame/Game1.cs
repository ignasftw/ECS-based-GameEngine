﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ECSGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public static ECSEngine.Scene.Scene curScene;
        public static Game1 instance;
        public static int pixelsPerUnit = 100;

        public static int ScreenWidth;
        public static int ScreenHeight;


        public ECSEngine.Entity.Entity[] entities = new ECSEngine.Entity.Entity[70];

        public int spawntime = 10;
        public int stime = 0;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            instance = this;
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
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
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

            // TODO: use this.Content to load your game content here
            MakeTestScene();
        }

        private void MakeTestScene()
        {
            Texture2D entitytexture = Content.Load<Texture2D>("entity");
            Texture2D bg = Content.Load<Texture2D>("Wallpaper2");

            curScene = new ECSEngine.Scene.Scene();

            //--------------------------------------------------
            // Adding the background
            //--------------------------------------------------
            ECSEngine.Entity.Entity background =
            curScene.AddEntity(
                new ECSEngine.Entity.Entity(
                    new Vector2(0, -0),
                    1f,
                    name: "Background",
                    tag: 0
                )
            );


            background.AddComponent(
                new ECSEngine.Component.Rendering.Sprite(
                    bg,
                    background,
                    0
                )
            );
            //--------------------------------------------------
            // Adding the floor
            //--------------------------------------------------
            ECSEngine.Entity.Entity entbottom =
                curScene.AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(0, ScreenHeight - 50),
                        0.1f,
                        name: "Floor collision",
                        tag: 0
                    )
                );


            entbottom.AddComponent(
                new ECSEngine.Component.Physics.Colliders.RectCollider(
                    entbottom,
                    3500f,
                    (float)ScreenHeight / 2,
                    Vector2.Zero
                )
            );


            //--------------------------------------------------
            // Adding multiple entities
            //--------------------------------------------------
            for (int i = 0; i < entities.Length; i++)
            {
                entities[i] =
                curScene.AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(1100 / entities.Length * i, -i * 2),
                        0.1f,
                        name: "Warrior " + i,
                        tag: 0
                    )
                );

                entities[i].AddComponent(
                new ECSEngine.Component.Rendering.Sprite(
                    entitytexture,
                    entities[i],
                    index: 0
                    )
                );

                entities[i].AddComponent(
                    new ECSEngine.Component.Physics.RigidBodies.Rigidbody(
                        entities[i]
                    )
                );

                entities[i].AddComponent(
                    new ECSEngine.Component.Physics.Colliders.RectCollider(
                        entities[i],
                        10f,
                        35f,
                        new Vector2(25f, 25f)
                    )
                );
            }
        }

        private void EndDemoScreen()
        {
            Texture2D bg = Content.Load<Texture2D>("YouWin");

            curScene = new ECSEngine.Scene.Scene();

            //--------------------------------------------------
            // Adding the background
            //--------------------------------------------------
            ECSEngine.Entity.Entity background =
            curScene.AddEntity(
                new ECSEngine.Entity.Entity(
                    new Vector2(0, -0),
                    1f,
                    name: "Background",
                    tag: 0
                )
            );

            background.AddComponent(
                new ECSEngine.Component.Rendering.Sprite(
                    bg,
                    background,
                    0
                )
            );
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (curScene.entities.Count > entities.Length + 10) EndDemoScreen();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                try
                {
                    spawnBullet();
                }
                catch (Exception e)
                {
                    throw new Exceptions.InvalidSpawnException("Could not spawn a bullet", e);
                }
            }

            // TODO: Add your update logic here
            curScene.Update(gameTime);

            base.Update(gameTime);
        }


        void spawnBullet()
        {
            if (stime == spawntime)
            {
                Texture2D bullettexture = Content.Load<Texture2D>("bullet");
                ECSEngine.Entity.Entity bullet;

                bullet =
                curScene.AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(100, 600),
                        0.5f,
                        name: "Bullet",
                        tag: 0
                    )
                );

                bullet.AddComponent(
                new ECSEngine.Component.Rendering.Sprite(
                    bullettexture,
                    bullet,
                    index: 0
                    )
                );

                bullet.AddComponent(
                    new ECSEngine.Component.Physics.RigidBodies.FixedSpeed(
                        bullet,
                        30,
                        0
                    )
                );

                bullet.AddComponent(
                    new ECSEngine.Component.Physics.Colliders.RectCollider(
                        bullet,
                        50f,
                        50f,
                        new Vector2(5f, 17f)
                    )
                );

                Console.WriteLine("Entity has been created. Count: " + +curScene.entities.Count);
                stime = 0;
            }
            else
            {
                stime++;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            ECSEngine.Rendering.Renderer.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
