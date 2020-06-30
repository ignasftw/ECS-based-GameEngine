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
        //DECLARE a Texture2D which will contain a texture which will have to be drawn, '_texture'
        private Texture2D _texture;
        //DECLARE a Color which will tell overlay colour, '_color'
        private Color _color = Color.White;
        //DECLARE an int which stores layer value, '_layerIndex'
        private int _layerIndex = 0;
        //DECLARE a bool which tells if the sprite contains text, call it '_hastxt'
        private bool _hastxt = false;

        /// <summary>
        /// CONSTRUCTOR: Initialising the sprite class
        /// </summary>
        /// <param name="txt">Texture2D, texture which needs to be rendered</param>
        /// <param name="attachee">Entity which has sprite</param>
        /// <param name="index">int, layer's value</param>
        public Sprite(Texture2D txt, Entity.Entity attachee, int index = 0)
            :base(attachee)
        {
            _texture = txt;
            _hastxt = true;
            _layerIndex = index;
            ECSEngine.Rendering.Renderer._sprites.Add(this);
        }

        /// <summary>
        /// METHOD: draws sprited
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            //If it does not contrain a sprite, then no need to render
            if (!_hastxt)
            {
                return;
            }

            sb.Draw(
                _texture,
                attachee.GetPosition(),
                null,
                _color,
                attachee.GetRotationZ(),
                Vector2.Zero, attachee.GetScale(),
                SpriteEffects.None,
                _layerIndex
            );
        }

        public override void Update(GameTime gt)
        {

        }
    }
}
