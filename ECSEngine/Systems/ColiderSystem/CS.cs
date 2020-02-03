using System;
using System.Collections.Generic;
using System.Text;

using ECSEngine.Component.Physics.Colliders;
using ECSEngine.Utils;
using Microsoft.Xna.Framework;

namespace ECSEngine.Systems.ColiderSystem
{
    public static class CS
    {
        private static float pushOutSpeed = 8, fixedDeltaTime = 0.01f, timer = 0;

        public static List<Collider> colliders = new List<Collider>();

        public static void Update(GameTime gt)
        {
            timer += (float)gt.ElapsedGameTime.TotalSeconds;
            if (timer >= fixedDeltaTime)
            {
                timer = 0;
                foreach (Collider c1 in colliders)
                {
                    foreach (Collider c2 in colliders)
                    {
                        if(c1 != c2 && DoCollide(c1, c2))
                        {
                            // TODO: redundancy -> check if it has rb then do these calculations
                            c1.Collide(0, PushSpeedVector(c1, c2));
                            c1.Collide(0, PushSpeedVector(c2, c1));
                        }
                    }
                }
            }
        }

        public static bool DoCollide(Collider c1, Collider c2)
        {
            if(c1 is CircleCollider)
            {
                if (c2 is CircleCollider)
                {
                    return DoCollide((CircleCollider)c1, (CircleCollider)c2);
                }
            }

            if (c1 is RectCollider)
            {
                if (c2 is RectCollider)
                {
                    
                    return DoCollide((RectCollider)c1, (RectCollider)c2);
                }
            }

            return false;
        }

        public static bool DoCollide(CircleCollider c1, CircleCollider c2)
        {
            float dist = MathUtils.GetDistance(c1.GetCenter(), c2.GetCenter());
            float radsum = c1.GetRadius() + c2.GetRadius();

            return dist <= radsum;
        }

        public static bool DoCollide(RectCollider c1, RectCollider c2)
        {
            Rectangle r1 = new Rectangle((int)c1.GetCenter().X, (int)c1.GetCenter().Y, (int)c1._width, (int)c1._height);
            Rectangle r2 = new Rectangle((int)c2.GetCenter().X, (int)c2.GetCenter().Y, (int)c2._width, (int)c2._height);

            
            return r1.Intersects(r2);
        }

        public static Vector2 PushSpeedVector(Collider ECSEngine, Collider second)
        {
            if(ECSEngine is CircleCollider)
            {
                if(second is CircleCollider)
                {
                    return PushSpeedVector((CircleCollider)ECSEngine, (CircleCollider)second);
                }
            }

            if (ECSEngine is RectCollider)
            {
                if (second is RectCollider)
                {
                    return PushSpeedVector((RectCollider)ECSEngine, (RectCollider)second);
                }
            }

            throw new NotImplementedException();

            //return Vector2.Zero;
        }

        public static Vector2 PushSpeedVector(CircleCollider ECSEngine, CircleCollider second)
        {
            Vector2 pushV = second.GetCenter() - ECSEngine.GetCenter();
            pushV.Normalize();
            return pushV * pushOutSpeed;
        }

        public static Vector2 PushSpeedVector(RectCollider ECSEngine, RectCollider second)
        {
            Vector2 pushV = new Vector2(0,second.GetTop()) - ECSEngine.GetCenter();
            pushV.Normalize();
            //return new Vector2(0,-1) * pushOutSpeed;
            return new Vector2(0,pushV.Y) * pushOutSpeed;
        }
    }
}
