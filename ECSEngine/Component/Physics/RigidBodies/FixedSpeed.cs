using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Component.Physics.RigidBodies
{
    public class FixedSpeed : ECSEngine.Component.Component
    {
        public Vector2 velocity;

        float xvel;
        public float distance = 0;

        public FixedSpeed(Entity.Entity attachee, float Xvelocity, float Yvelocity) : base(attachee)
        {
            velocity = new Vector2(Xvelocity, Yvelocity);
            xvel = Xvelocity;
        }

        public override void Update(GameTime gt)
        {
            if(distance<800)
            {
                attachee.transform.Translate(velocity * 100 * (float)gt.ElapsedGameTime.TotalSeconds);
                distance += xvel;
            }

        }
    }
}
