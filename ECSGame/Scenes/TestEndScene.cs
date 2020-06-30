using ECSEngine.Component.Rendering;
using ECSGame.Component.Physics.RigidBodies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ECSGame.Scenes
{
    public class TestEndScene : ECSEngine.Scene.Scene
    {
        //DECLARE a ContentManager which would allow to load Texture2D, call it '_content'
        ContentManager _content;

        /// <summary>
        /// Constructor: Create TestEndScene class
        /// </summary>
        /// <param name="content">ContentManager which allows load Texture2D</param>
        public TestEndScene(ContentManager content)
        {
            _content = content;
            InitializeEndDemoScene();
        }

        /// <summary>
        /// METHOD: Initializes "TestEndScene"
        /// </summary>
        private void InitializeEndDemoScene()
        {
            //Loading a background texture
            Texture2D bg = _content.Load<Texture2D>("YouWin");

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
            //Add sprite component to render the texture
            background.AddComponent(
                new Sprite(
                    bg,
                    background,
                    0
                )
            );
        }
    }
}
