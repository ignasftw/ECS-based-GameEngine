using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSGame.Component.Physics.RigidBodies
{
    public class FixedSpeed : ECSEngine.Component.Component
    {
        private Vector2 velocity;

        private float xvel;
        private float distance = 0;

        public FixedSpeed(ECSEngine.Entity.Entity attachee, float Xvelocity, float Yvelocity) : base(attachee)
        {
            velocity = new Vector2(Xvelocity, Yvelocity);
            xvel = Xvelocity;
        }

        public override void Update(GameTime gt)
        {
            if(distance<800)
            {
                attachee.Transform(velocity * 100 * (float)gt.ElapsedGameTime.TotalSeconds);
                distance += xvel;
            }

        }
    }
}
