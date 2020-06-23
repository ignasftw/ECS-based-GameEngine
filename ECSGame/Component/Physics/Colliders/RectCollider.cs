﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSGame.Component.Physics.Colliders
{
    public class RectCollider : Collider
    {
        private Vector2 _center;
        private float _width, _height;
        private Action<Collider> _addCollider;

        public RectCollider(ECSEngine.Entity.Entity attachee, float width, float height, Vector2 center, Action<Collider> addCollider) : base(attachee) 
        {
            _width = width;
            _height = height;
            _center = center;
            addCollider(this);
        }

        protected override Vector2 GetGlobalCenter()
        {
            return _center + attachee.GetPosition();
        }

        public override float GetBottom()
        {
            return GetGlobalCenter().Y + _height / 2;
        }

        public override Vector2 GetCenter()
        {
            return GetGlobalCenter();
        }

        public override float GetLeft()
        {
            return GetGlobalCenter().X - _width / 2;
        }

        public override float GetRight()
        {
            return GetGlobalCenter().X + _width / 2;
        }

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

        public override void Collide(int dir, Vector2 pushVector)
        {
            Collide(pushVector);
        }

        public void Collide(Vector2 pushVector)
        {
            if (hasRB)
            {
                rb.Collision(pushVector);
            }
        }

        public Vector2 GetDimensions()
        {
            return new Vector2(_width,_height);
        }
    }
}
