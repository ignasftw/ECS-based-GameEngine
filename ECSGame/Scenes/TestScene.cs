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
        //DECLARE a static int, this allows to choose how many entities to create into a simulation call it 'WarriorAmount'
        public readonly static int WarriorAmount = 200;
        //DECLARE an array of entities which will allow to store multiple entities
        private ECSEngine.Entity.Entity[] _warriors = new ECSEngine.Entity.Entity[WarriorAmount];
        //DECLARE an int which will store screen's width, call it '_screenWidth', set default to '800'
        private int _screenWidth = 800;
        //DECLARE an int which will store screen's height, call it '_screenHeight', set default to '600'
        private int _screenHeight = 600;
        //DECLARE an int which aloows after certain amount of loops to spawn another entity, call it '_spawntime'
        private readonly int _spawntime = 10;
        //DECLARE an tin which will count time until spawntime, call it '_stime'
        private int _stime = 0;
        //DECLARE an Action which would send a collider component to a system,call it '_addCollider'
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
            //Load textures required for this scene
            Texture2D entitytexture = _content.Load<Texture2D>("entity");
            Texture2D bg = _content.Load<Texture2D>("Wallpaper2");

            //Create a background entity
            ECSEngine.Entity.Entity background =
            AddEntity(
                new ECSEngine.Entity.Entity(
                    new Vector2(0, -0),
                    1f,
                    name: "Background",
                    tag: 0
                )
            );

            //Add sprite component to a background
            background.AddComponent(
                new Sprite(
                    bg,
                    background,
                    0
                )
            );

            //Add floor collision entity
            ECSEngine.Entity.Entity entbottom =
                AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(0, _screenHeight - 50),
                        0.1f,
                        name: "Floor collision",
                        tag: 0
                    )
                );

            //Add rectangle collider component
            entbottom.AddComponent(
                new RectCollider(
                    entbottom,
                    3500f,
                    (float)_screenHeight / 2,
                    Vector2.Zero,
                    _addCollider
                )
            );

            //Declare an int for X position which will spread the spawn warriors
            int xposition = 100;
            //Declare an int for Y position which will spread the spawn warriors
            int yposition = 400;

            //For the lenght of array
            for (int i = 0; i < _warriors.Length; i++)
            {
                //IF xposition is larger than 1100
                if (xposition > 1100)
                {
                    //Reset X position
                    xposition = 100;
                }
                else
                {
                    //Increment x Position by 2
                    xposition += 2;
                }
                //Create a warrior within the calculated position
                _warriors[i] =
                AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(30 + xposition, yposition - i),
                        0.1f,
                        name: "Warrior " + i,
                        tag: 0
                    )
                );

                //Add a sprite rendering component
                _warriors[i].AddComponent(
                new Sprite(
                    entitytexture,
                    _warriors[i],
                    index: 0
                    )
                );

                //Add a RigidBody component
                _warriors[i].AddComponent(
                    new Rigidbody(
                        _warriors[i]
                    )
                );

                //Add a Rectangle Collider Component
                _warriors[i].AddComponent(
                    new RectCollider(
                        _warriors[i],
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
            //If the settime is larger than spawn time
            if (_stime >= _spawntime)
            {
                //Load the bullet texture
                Texture2D bullettexture = _content.Load<Texture2D>("bullet");
                ECSEngine.Entity.Entity bullet;
                //Create a new bullet on the left of the sceen
                bullet =
                AddEntity(
                    new ECSEngine.Entity.Entity(
                        new Vector2(100, 600),
                        0.5f,
                        name: "Bullet",
                        tag: 0
                    )
                );
                //Add a sprite rendering component
                bullet.AddComponent(
                new Sprite(
                    bullettexture,
                    bullet,
                    index: 0
                    )
                );
                //Add a constant speed component to a bullet
                bullet.AddComponent(
                    new FixedSpeed(
                        bullet,
                        30,
                        0
                    )
                );
                //Add a rectangular collider
                bullet.AddComponent(
                    new Component.Physics.Colliders.RectCollider(
                        bullet,
                        50f,
                        50f,
                        new Vector2(5f, 17f),
                        _addCollider
                    )
                );
                //Set timer to '0'
                _stime = 0;
            }
            //Else the timer is not ready to spawn a bullet
            else
            {
                //Increment by 1
                _stime++;
            }
        }
    }
}
