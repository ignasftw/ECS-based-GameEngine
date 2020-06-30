using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSEngine.Rendering
{
    ///<summary>
    /// This class was used for reference of how rendering was implemented 
    /// Mamatosen. 2019. Mamatosen/monogame-ecs-base. [Online]. [7 January 2020]. 
    /// Available from: https://github.com/mamatosen/monogame-ecs-base
    /// </summary>
    public static class Renderer
    {
        //DECLARE a static list of sprite components
        public static List<Component.Rendering.Sprite> _sprites = new List<Component.Rendering.Sprite>();

        /// <summary>
        /// METHOD: draws all sprites that was added to a list
        /// </summary>
        /// <param name="sb">Spritebatch that contains sprites</param>
        public static void Draw(SpriteBatch sb)
        {
            //Foreach sprite in the list draw a sprite
            foreach (Component.Rendering.Sprite sprite in _sprites)
            {
                sprite.Draw(sb);
            }
        }
    }
}
