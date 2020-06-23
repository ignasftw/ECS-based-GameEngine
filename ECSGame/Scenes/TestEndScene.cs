using ECSEngine.Component.Rendering;
using ECSGame.Component.Physics.RigidBodies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ECSGame.Scenes
{
    class TestEndScene : ECSEngine.Scene.Scene
    {
        //DECLARE a ContentManager which would allow to load Texture2D, call it '_content'
        ContentManager _content;

        public TestEndScene(ContentManager content)
        {
            _content = content;
            InitializeEndDemoScene();
        }

        private void InitializeEndDemoScene()
        {
            Texture2D bg = _content.Load<Texture2D>("YouWin");

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
        }
    }
}
