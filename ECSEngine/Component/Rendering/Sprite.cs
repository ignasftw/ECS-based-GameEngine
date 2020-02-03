using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/// <summary>
/// Mamatosen. 2019. Mamatosen/monogame-ecs-base. [Online]. [7 January 2020]. 
/// Available from: https://github.com/mamatosen/monogame-ecs-base
/// </summary>
/// 
namespace ECSEngine.Component.Rendering
{
    public class Sprite : ECSEngine.Component.Component
    {
        public Texture2D texture;
        public Color color = Color.White;
        public int layerIndex = 0;
        private bool _hastxt = false;

        public Sprite(Texture2D txt, Entity.Entity attachee, int index = 0)
            :base(attachee)
        {
            texture = txt;
            _hastxt = true;
            layerIndex = index;
            ECSEngine.Rendering.Renderer.sprites.Add(this);
        }

        public void Draw(SpriteBatch sb)
        {
            if (!_hastxt)
            {
                return;
            }

            sb.Draw(
                texture,
                attachee.transform.position,
                null,
                color,
                attachee.transform.rotationZ,
                Vector2.Zero, attachee.transform.scale,
                SpriteEffects.None,
                layerIndex
            );
        }

        public override void Update(GameTime gt)
        {

        }
    }
}
