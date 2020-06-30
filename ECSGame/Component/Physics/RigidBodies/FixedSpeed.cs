using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSGame.Component.Physics.RigidBodies
{
    public class FixedSpeed : ECSEngine.Component.Component
    {
        //DECLARE a Vector2 which tells current velocity, call it '_velocity'
        private Vector2 _velocity;
        //DECLARE a float the constant speed if should be in X axis, call it '_xVel'
        private float _xVel;
        //DECLARE a float the constant speed if should be in Y axis, call it '_yVel'
        private float _yVel;
        //DECLARE a float which keeps track on distance for optimazation, call it '_distance'
        private float _distance = 0;

        /// <summary>
        /// CONSTRUCTOR: Initializes FixedSpeed component
        /// </summary>
        /// <param name="attachee">Entity which contain this component</param>
        /// <param name="Xvelocity"></param>
        /// <param name="Yvelocity"></param>
        public FixedSpeed(ECSEngine.Entity.Entity attachee, float Xvelocity, float Yvelocity) : base(attachee)
        {
            _velocity = new Vector2(Xvelocity, Yvelocity);
            _xVel = Xvelocity;
            _yVel = Yvelocity;
        }

        /// <summary>
        /// METHOD: behaviour which transforms the object at constant speed while its on screen
        /// </summary>
        /// <param name="gt">Information about game time</param>
        public override void Update(GameTime gt)
        {
            //If the distance traveled less than 800
            if(_distance<800)
            {
                //Update the tranform component depending on current velocity
                attachee.Transform(_velocity * 100 * (float)gt.ElapsedGameTime.TotalSeconds);
                _distance += _xVel;
                _distance += _yVel;
            }

        }
    }
}
