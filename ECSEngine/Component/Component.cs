using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using ECSEngine.Entity;

namespace ECSEngine.Component
{
    public abstract class Component : IECSActor
    {
        public Entity.Entity attachee;

        public Component(Entity.Entity attachee)
        {
            this.attachee = attachee;
        }

        public abstract void Update(GameTime gt);
    }
}