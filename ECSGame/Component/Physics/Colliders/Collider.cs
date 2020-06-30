using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSGame.Component.Physics.Colliders
{
    public abstract class Collider : ECSEngine.Component.Component, ECSEngine.IVDebuggable
    {
        //DECLARE a bool which tells if the colliders has RigidBody, call it '_hasRB'
        protected bool _hasRB;
        //DECLARE a Rigidbody which contains a reference to a RigidBody, call it '_rb'
        protected RigidBodies.Rigidbody _rb;

        /// <summary>
        /// CONSTRUCTOR: Initializes the collider's component
        /// </summary>
        /// <param name="attachee">Entity which contains this component</param>
        public Collider(ECSEngine.Entity.Entity attachee) : base(attachee)
        {
            _rb = attachee.FindComponent<RigidBodies.Rigidbody>();           
            _hasRB = _rb != null;
        }

        abstract protected Vector2 GetGlobalCenter();

        abstract public float GetTop(); // min y
        abstract public Vector2 GetCenter();
        abstract public void Draw(SpriteBatch sb);
        abstract public void Collide(int dir, Vector2 pushVector);
    }
}
