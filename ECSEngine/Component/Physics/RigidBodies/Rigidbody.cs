using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Component.Physics.RigidBodies
{
    public class Rigidbody : ECSEngine.Component.Component
    {
        public static float gravity = 9.8f;

        public bool affectedByGravity = true;
        public Vector2 velocity;

        public Rigidbody(Entity.Entity attachee):base(attachee)
        {
            velocity = Vector2.Zero;
        }

        public override void Update(GameTime gt)
        {
            if (affectedByGravity)
            {
                velocity = new Vector2(velocity.X, velocity.Y + (gravity * (float)gt.ElapsedGameTime.TotalSeconds));
            }

            attachee.transform.Translate(velocity * 100 * (float)gt.ElapsedGameTime.TotalSeconds);
        }
    }
}
