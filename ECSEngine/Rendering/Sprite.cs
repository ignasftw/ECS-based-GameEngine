using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


///<summary>
/// This class was used for reference of how rendering was implemented 
/// Mamatosen. 2019. Mamatosen/monogame-ecs-base. [Online]. [7 January 2020]. 
/// Available from: https://github.com/mamatosen/monogame-ecs-base
/// </summary>
/// 
namespace ECSEngine.Component.Rendering
{
    public class Sprite : ECSEngine.Component.Component
    {
        private Texture2D texture;
        private Color color = Color.White;
        private int layerIndex = 0;
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
                attachee.GetPosition(),
                null,
                color,
                attachee.GetRotationZ(),
                Vector2.Zero, attachee.GetScale(),
                SpriteEffects.None,
                layerIndex
            );
        }

        public override void Update(GameTime gt)
        {

        }
    }
}
