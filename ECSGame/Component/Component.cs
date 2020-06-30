using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using ECSEngine.Entity;

namespace ECSGame.Component
{
    public abstract class Component : ECSEngine.IUpdatable
    {
        //DECLARE an Entity which contains this component, call it '_attachee'
        public Entity _attachee;

        /// <summary>
        /// Constructor: Initializes a component
        /// </summary>
        /// <param name="attachee"></param>
        public Component(Entity attachee)
        {
            this._attachee = attachee;
        }

        public abstract void Update(GameTime gt);
    }
}