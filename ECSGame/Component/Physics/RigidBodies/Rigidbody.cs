using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSGame.Component.Physics.RigidBodies
{
    public class Rigidbody : ECSEngine.Component.Component
    {
        //DECLARE a float which will keep gravity speed value, call it '_gravity'
        private float _gravity = 9.8f;
        //DECLARE a bool which will tell if gravity pulls the object, call it '_isGravity'
        private bool _isGravity = true;
        //DECLARE a Vector2 which will tell x and y velocity, call it '_velocity'
        private Vector2 _velocity;

        public Rigidbody(ECSEngine.Entity.Entity attachee):base(attachee)
        {
            _velocity = Vector2.Zero;
        }

        /// <summary>
        /// METHOD: Updates the object accordingly to deltaTime and velocity
        /// </summary>
        /// <param name="gt">Data about game time</param>
        public override void Update(GameTime gt)
        {
            //IF the gravity is effecting the object then apply gravity force
            if (_isGravity)
            {
                //Add gravity force to current velocity, accordingly to delta Time
                _velocity = new Vector2(_velocity.X, _velocity.Y + (_gravity * (float)gt.ElapsedGameTime.TotalSeconds));
            }
            //Transform the object accordingly to velocity
            attachee.Transform(_velocity * 100 * (float)gt.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        /// METHOD: if the collision happend set the velocity to pushvector
        /// </summary>
        /// <param name="pushVector">Vector2 which shows how to bounceOff</param>
        public void Collision(Vector2 pushVector)
        {
            _velocity = pushVector;
        }
    }
}
