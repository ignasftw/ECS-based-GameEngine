using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Entity
{
    public class Entity : IUpdatable
    {
        public Scene.Scene attachee;
        public List<Component.Component> components;
        public ECSEngine.Component.Transform.Transform2D transform;
        public string name;
        public int tag; // tag = -1 means the tag has not been assigned

        public Entity(Vector2 position, float scale, string name = "Game Object", int tag = -1)
        {
            this.name = name;
            this.tag = tag;
            this.transform = new ECSEngine.Component.Transform.Transform2D(position, scale, this);
            components = new List<Component.Component>();
        }

        public void Update(GameTime gt)
        {
            CallComponentsUpdates(gt);
        }

        public void AddComponent(ECSEngine.Component.Component comp)
        {
            if (!(comp is ECSEngine.Component.Transform.Transform2D))
            {
                components.Add(comp);
            }
        }

        public T FindComponent<T>() where T : ECSEngine.Component.Component
        {
            foreach(Component.Component cmp in components)
            {
                if(cmp is T)
                {
                    return (T)cmp;
                }
            }
            return null;
        }

        public void RemoveComponent<T>() where T : ECSEngine.Component.Component
        {
            foreach (Component.Component cmp in components)
            {
                if(cmp is T)
                {
                    components.Remove(cmp);
                }
            }

        }

        public void RemoveAllComponents()
        {
            throw new NotImplementedException();
        }

        private void CallComponentsUpdates(GameTime gt)
        {
            foreach (Component.Component cmp in components)
            {
                cmp.Update(gt);
            }
        }
    }
}
