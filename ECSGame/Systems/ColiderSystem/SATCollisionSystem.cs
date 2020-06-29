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

        //    //AABB(Rectangle) only needs 2 axes which should be normals of shape's edges
        //    Vector2[] Axes = new Vector2[2];


        //    /*
        //     Every Update shapes should check either they are colliding
        //     By cheking axis which are normals of the shapes
        //     */
        //    bool Intersect(Collider a1, Collider b1)
        //    {

        //        for (int i = 0; i < Axes.Length; i++)
        //        {
        //            Vector2 axis = Axes[i];
        //        }

        //        //Project both shapes into axis

        //        //Projection p1 = shape1.project(axis);
        //        //Projection p2 = shape2.project(axis);

        //        //do the projections overlap
        //        /*!p1.overlap(p2)* does axis1 overlap with axis2 */
        //        if (false && true)
        //        {
        //            //One of axis does NOT overlap
        //            return false;
        //        }

        //        //If every axis didn't return false then
        //        //very likely that the intersection occurs
        //        return true;
        //    }

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
