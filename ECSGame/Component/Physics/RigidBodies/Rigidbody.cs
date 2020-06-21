using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSGame.Component.Physics.RigidBodies
{
    public class Rigidbody : ECSEngine.Component.Component
    {
        private static float gravity = 9.8f;

        private bool affectedByGravity = true;
        private Vector2 velocity;

        public Rigidbody(ECSEngine.Entity.Entity attachee):base(attachee)
        {
            velocity = Vector2.Zero;
        }

        public override void Update(GameTime gt)
        {
            if (affectedByGravity)
            {
                velocity = new Vector2(velocity.X, velocity.Y + (gravity * (float)gt.ElapsedGameTime.TotalSeconds));
            }
            if(attachee.GetPosition().Y > 600)
            {
                if(velocity.Y>0)
                velocity = -velocity;
            }

            if (attachee.GetPosition().Y < -2000)
            {
                if (velocity.Y < 0)
                    velocity = -velocity;
            }
            attachee.Transform(velocity * 100 * (float)gt.ElapsedGameTime.TotalSeconds);
        }

        public void Collision(Vector2 pushVector)
        {
            velocity = pushVector;
        }
    }
}
