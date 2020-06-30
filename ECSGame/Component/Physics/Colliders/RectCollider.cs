using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSGame.Component.Physics.Colliders
{
    public class RectCollider : Collider
    {
        //DECLARE a Vector2 describes where is the center of the collider, call it '_center'
        private Vector2 _center;
        //DECLARE a float describes the width and the height of the collider, call it '_width', '_height'
        private float _width, _height;

        /// <summary>
        /// CONSTRUCTOR: Initializes the rectangle collider
        /// </summary>
        /// <param name="attachee">Entity which contains the collider</param>
        /// <param name="width">Width of the collider</param>
        /// <param name="height">Height of the collider</param>
        /// <param name="center">The center of the collider</param>
        /// <param name="addCollider">Delegate which sends the component to a list</param>
        public RectCollider(ECSEngine.Entity.Entity attachee, float width, float height, Vector2 center, Action<Collider> addCollider) : base(attachee) 
        {
            _width = width;
            _height = height;
            _center = center;
            addCollider(this);
        }

        /// <summary>
        /// METHOD: Returns global center of the shape
        /// </summary>
        /// <returns>Vector2 global coordinates of the collider's shape</returns>
        protected override Vector2 GetGlobalCenter()
        {
            return _center + attachee.GetPosition();
        }

        /// <summary>
        /// METHOD: Returns local center of the shape
        /// </summary>
        /// <returns>Vector2 local coordinates of the collider's shape</returns>
        public override Vector2 GetCenter()
        {
            return GetGlobalCenter();
        }

        /// <summary>
        /// METHOD: Returns the Y coordinate of the shape's top collider
        /// </summary>
        /// <returns>Vector2 local coordinates of the collider's shape</returns>
        public override float GetTop()
        {
            return GetGlobalCenter().Y - _height / 2;
        }

        public override void Update(GameTime gt)
        {

        }

        public override void Draw(SpriteBatch sb)
        {

        }

        /// <summary>
        /// METHOD: Pushes vector after collision occured
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pushVector"></param>
        public override void Collide(int dir, Vector2 pushVector)
        {
            Collide(pushVector);
        }

        public void Collide(Vector2 pushVector)
        {
            if (_hasRB)
            {
                _rb.Collision(pushVector);
            }
        }

        /// <summary>
        /// METHOD: get dimensions of a collider
        /// </summary>
        /// <returns>Vector2, x is width, and y is height of collider</returns>
        public Vector2 GetDimensions()
        {
            return new Vector2(_width,_height);
        }
    }
}
