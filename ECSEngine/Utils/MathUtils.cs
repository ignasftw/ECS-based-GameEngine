using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Utils
{
    public static class MathUtils
    {
        public static float GetDistance(Vector2 v1, Vector2 v2)
        {
            double distance = Math.Sqrt(((v1.X - v2.X)* (v1.X - v2.X) + (v1.Y - v2.Y)* (v1.Y - v2.Y)));

            return (float)distance;
        }
    }
}
