using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSEngine.Rendering
{
    public static class Renderer
    {
        public static List<Component.Rendering.Sprite> sprites = new List<Component.Rendering.Sprite>();
        public static List<ECSEngine.Component.IVDebuggable> VDs = new List<ECSEngine.Component.IVDebuggable>();

        public static void Draw(SpriteBatch sb)
        {
            foreach (Component.Rendering.Sprite sprite in sprites)
            {
                sprite.Draw(sb);
            }

            foreach (ECSEngine.Component.IVDebuggable VD in VDs)
            {
                VD.Draw(sb);
            }
        }
    }
}
