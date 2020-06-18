using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ECSGame.Component.Physics.Colliders
{
    public abstract class Collider : ECSEngine.Component.Component, ECSEngine.IVDebuggable
    {
        public static bool renderColliders = false;

        protected bool hasRB, lc, rc, dc, uc;
        protected RigidBodies.Rigidbody rb;

        public Collider(ECSEngine.Entity.Entity attachee) : base(attachee)
        {
            rb = attachee.FindComponent<RigidBodies.Rigidbody>();           
            hasRB = rb != null;
            Systems.ColiderSystem.CS.AddCollider(this);
            ECSEngine.Rendering.Renderer.VDs.Add(this);
        }

        abstract protected Vector2 GetGlobalCenter();

        abstract public float GetLeft(); // min x
        abstract public float GetRight(); // max x
        abstract public float GetTop(); // min y
        abstract public float GetBottom(); // max y
        abstract public Vector2 GetCenter();
        abstract public void Draw(SpriteBatch sb);
        abstract public void Collide(int dir, Vector2 pushVector);
    }
}
