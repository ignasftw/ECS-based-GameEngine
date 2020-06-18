using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using ECSEngine.Entity;

namespace ECSGame.Component
{
    public abstract class Component : ECSEngine.IUpdatable
    {
        public Entity attachee;

        public Component(Entity attachee)
        {
            this.attachee = attachee;
        }

        public abstract void Update(GameTime gt);
    }
}