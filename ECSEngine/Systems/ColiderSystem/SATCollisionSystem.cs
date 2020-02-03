using System;
using System.Collections.Generic;
using System.Text;

using ECSEngine.Component.Physics.Colliders;
using ECSEngine.Utils;
using Microsoft.Xna.Framework;

namespace ECSEngine.Systems.ColiderSystem

/*
 * This class was reconstructed by using a reference included in:
    Charry, J. (2017). Building a Physics Engine, Pt. 10 - Collision Detection using Separating Axis Theorem (SAT)
    [online] Jcharry.com. Available at: https://jcharry.com/blog/physengine10 [Accessed 3 Feb. 2020].
*/
{
    public static class SATCollisionSystem
    {
        const SAT;

        /// <summary>
        ///METHOD: This method checks 2 shapes and redirects to proper collision test
        /// </summary>
        void intersect(Collider a1, Collider b1)
        {
            /* CASE 1 interaction
             *  
             *  Rectangle OR Polygon
             *  interacts with other shapes
            */

            //Rectangle/Polygon collides with Circle
            if (a1 is RectCollider || a1 is PolygonCollider)
            {
                if (b1 is CircleCollider)
                {
                    polycircle(a1, b1);
                    break;
                }

                //Rectangle/Polygon with
                //Rectangle/Polygon
                polypoly(a1, b1);
                break;
            }

            /* CASE 2 interaction
             *  
             *  Circle 
             *  interacts with other shapes
            */

            //Circle collides with circle
            if (a1 is CircleCollider)
            {
                if (b1 is CircleCollider)
                {
                    circlecircle(a1, b1);
                    break;
                }
                //Circle with
                //Rectangle/Polygon
                polycircle(a1, b1);
                break;
            }
        }


        /*
         * METHOD: this method checks a collision between two circles
         * PARAMETERS: 
         * CircleCollider a1, first shape of collision check
         * CircleCollider b1, second shape of collision check
         * 
         * RETURN: 
         * Vector2, should return the lenght of intersecting if it does
         * ELSE
         * return new Vector2(0,0);
        */
        void circlecircle(CircleCollider a1, CircleCollider b1)
        {
            //Declairing a Vector2, which will store a vector between two centers, call it 'v1'
            Vector2 v1 = Vector2.Subtract(a1.GetCenter,b1.GetCenter);
            //Declaire a float, which stores the distance between the vectors, call it 'distance'
            float distance = v1.Length();
            //Declaire a float, which will store sum between radiuses so the collision diantace would be known, call it 'rplusr'
            float rplusr = a1.GetRadius() + b1.GetRadius();

            //Check is two objects are intesecting
            if(distance < rplusr)
            {
                Vector2 c2toc1 = Vector2.Subtract(c2.position, c1.position);
                //Check if vectors are on the proper axis
                if (Vector2.Dot(v1,c2toc1) > 0)
                {
                    v1 *= -1;
                }

                //Collision is happening redirect to collision
                collision(a1, b1, v1.Normalize(), rplusr-distance);
                break;
            }
        }

        void polypoly()
        {

        }

        void polycircle()
        {

        }

    }
}
