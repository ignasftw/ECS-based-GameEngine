using ECSEngine.Component.Rendering;
using ECSGame.Component.Physics.RigidBodies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ECSGame.Component.Physics.Colliders;
using System;

namespace ECSGame.Scenes
{
    public class TestScene : ECSEngine.Scene.Scene, ECSEngine.Inputs.IInputListener
    {
        //DECLARE a ContentManager which would allow to load Texture2D, call it '_content'
        ContentManager _content;
        //DECLARE an array of entities which will allow to store multiple entities
        private ECSEngine.Entity.Entity[] _warriors = new ECSEngine.Entity.Entity[70];
        //DECLARE an int which will store screen's width, call it '_screenWidth', set default to '800'
        private int _screenWidth = 800;
        //DECLARE an int which will store screen's height, call it '_screenHeight', set default to '600'
        private int _screenHeight = 600;
        //DECLARE an int which aloows after certain amount of loops to spawn another entity, call it '_spawntime'
        private readonly int _spawntime = 10;
        //DECLARE an tin which will count time until spawntime, call it '_stime'
        private int _stime = 0;
        private Action<Collider> _addCollider;

        /// <summary>
        /// Constructor of the TestScene
        /// </summary>
        /// <param name="content">ContentManger which allows to load Texture2D files</param>
        /// <param name="addCollider">Action which helps to add component to a certain system</param>
        /// <param name="width">Width of the game screen</param>
        /// <param name="height">Height of the game screen</param>
        public TestScene(Action<Collider> addCollider,ContentManager content, int width, int height)
        {
            _content = content;
            _screenWidth = width;
            _screenHeight = height;
            _addCollider = addCollider;
            InitializeDemoScene();
        }

        /// <summary>
        /// METHOD: Initializes the Scene
        /// </summary>
        private void InitializeDemoScene()
        {
            Texture2D entitytexture = _content.Load<Texture2D>("entity");
            Texture2D bg = _content.Load<Texture2D>("Wallpaper2");

            //--------------------------------------------------
            // Adding the background
            //--------------------------------------------------
            ECSEngine.Entity.Entity background =
            AddEntity(
                new ECSEngine.Entity.Entity(
                    new Vector2(0, -0),
                    1f,
                    name: "Background",
                    tag: 0
                )
            );

            background.AddComponent(
                new Sprite(
                    bg,
                    background,
                    0
                )
            );
            //--------------------------------------------------
            // Adding the floor
            //--------------------------------------------------
            ECSEngine.Entity.Entity entbottom =
                AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(0, _screenHeight - 50),
                        0.1f,
                        name: "Floor collision",
                        tag: 0
                    )
                );


            entbottom.AddComponent(
                new RectCollider(
                    entbottom,
                    3500f,
                    (float)_screenHeight / 2,
                    Vector2.Zero,
                    _addCollider
                )
            );

            int xposition = 0;
            int yposition = -100;
            //--------------------------------------------------
            // Adding multiple entities
            //--------------------------------------------------
            for (int i = 0; i < _warriors.Length; i++)
            {
                if (xposition > 1100)
                {
                    xposition = 0;
                    yposition -= 10;
                }
                else
                {
                    xposition += 10;
                }
                _entities[i] =
                AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(30 + xposition, yposition - i),
                        0.1f,
                        name: "Warrior " + i,
                        tag: 0
                    )
                );

                _entities[i].AddComponent(
                new Sprite(
                    entitytexture,
                    _entities[i],
                    index: 0
                    )
                );

                _entities[i].AddComponent(
                    new Rigidbody(
                        _entities[i]
                    )
                );

                _entities[i].AddComponent(
                    new Component.Physics.Colliders.RectCollider(
                        _entities[i],
                        1f,
                        20f,
                        new Vector2(25f, 25f),
                        _addCollider
                    )
                );
            }
        }

        /// <summary>
        /// METHOD: Listener which actives whenever the observer detects pressed spacebar
        /// </summary>
        public void SpacebarIsDown()
        {
            SpawnBullet();
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
        }


        /// <summary>
        /// METHOD: allows to spawn bullet whenever the spacebar is pressed
        /// </summary>
        void SpawnBullet()
        {
            if (_stime >= _spawntime)
            {
                Texture2D bullettexture = _content.Load<Texture2D>("bullet");
                ECSEngine.Entity.Entity bullet;

                bullet =
                AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(100, 600),
                        0.5f,
                        name: "Bullet",
                        tag: 0
                    )
                );

                bullet.AddComponent(
                new Sprite(
                    bullettexture,
                    bullet,
                    index: 0
                    )
                );

                bullet.AddComponent(
                    new FixedSpeed(
                        bullet,
                        30,
                        0
                    )
                );

                bullet.AddComponent(
                    new Component.Physics.Colliders.RectCollider(
                        bullet,
                        50f,
                        50f,
                        new Vector2(5f, 17f),
                        _addCollider
                    )
                );

                bullet.AddComponent(
                new Rigidbody(
                    bullet
                )
            );
                _stime = 0;
            }
            else
            {
                _stime++;
            }
        }
    }
}
