using System;
using System.Collections.Generic;
using System.Text;
using ECSEngine.Utils;
using ECSGame.Component.Physics.Colliders;
using Microsoft.Xna.Framework;

namespace ECSGame.Systems.ColiderSystem

/*
 * REFERENCES:
 * 
 * *NOT USED*
    Charry, J. (2017). Building a Physics Engine, Pt. 10 - Collision Detection using Separating Axis Theorem (SAT)
    [online] Jcharry.com. Available at: https://jcharry.com/blog/physengine10 [Accessed 3 Feb. 2020].

    William Bittle (2010). SAT (Separating Axis Theorem)
    [online] Available at: http://www.dyn4j.org/2010/01/sat/ [Accessed 3 Feb. 2020].
 */
{
    public class SATCollisionSystem
    {

        //AABB(Rectangle) only needs 2 axes which should be normals of shape's edges
        Vector2[] Axes = new Vector2[2];


        /*
         Every Update shapes should check either they are colliding
         By cheking axis which are normals of the shapes
         */
        bool Intersect(Collider a1, Collider b1)
        {

            for (int i = 0; i < Axes.Length; i++)
            {
                Vector2 axis = Axes[i];
            }

            //Project both shapes into axis

            //Projection p1 = shape1.project(axis);
            //Projection p2 = shape2.project(axis);

            //do the projections overlap
            /*!p1.overlap(p2)* does axis1 overlap with axis2 */
            if (false && true)
            {
                //One of axis does NOT overlap
                return false;
            }

            //If every axis didn't return false then
            //very likely that the intersection occurs
            return true;
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
        void Circlecircle(CircleCollider a1, CircleCollider b1)
        {
            //Declairing a Vector2, which will store a vector between two centers, call it 'v1'
            Vector2 v1 = Vector2.Subtract(a1.GetCenter(), b1.GetCenter());
            //Declaire a float, which stores the distance between the vectors, call it 'distance'
            float distance = v1.Length();
            //Declaire a float, which will store sum between radiuses so the collision diantace would be known, call it 'rplusr'
            float rplusr = a1.GetRadius() + b1.GetRadius();

            //Check is two objects are intesecting
            if(distance < rplusr)
            {
                /*
                 * This Should calculate of how much Circles are overlaping
                 */
            }
        }

        void PolyPoly(PolygonCollider a1, PolygonCollider b1)
        {

        }

        void PolyCircle(PolygonCollider a1, CircleCollider b1)
        {

        }
        /*
         * All the possible collision combinations:
         
         Circle-> Rectangle
         Circle-> Circle
         Circle-> Polygon

        (AABB)
         Rectangle -> Circle
         Rectangle -> Rectangle
         Rectangle -> Polygon

         Polygon -> Circle
         Polygon -> Rectangle
         Polygon -> Polygon

         */
    }
}
