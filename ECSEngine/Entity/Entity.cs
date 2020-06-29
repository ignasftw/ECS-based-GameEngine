using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Entity
{
    public class Entity : IUpdatable
    {
        //DECLARE an Action which sends a component to a scene ,call it '_SendComp'
        private Action<Component.Component> _SendComp;
        //DECLARE a List which contains entitie's components, call it '_components'
        private List<Component.Component> _components;
        //DECLARE a transform component every entity should have a transform component, call it '_transform'
        private ECSEngine.Component.Transform.Transform2D _transform;
        //DECLARE a string which tells the name of the entity, call it '_name'
        private string _name;
        //DECLARE an int which can tag certain types of entities
        private int _tag;

        public Entity(Vector2 position, float scale, string name = "Game Object", int tag = -1)
        {
            _components = new List<Component.Component>();

            this._name = name;
            this._tag = tag;
            this._transform = new ECSEngine.Component.Transform.Transform2D(position, scale, this);
        }

        public void SendComponent(Action<Component.Component> SendComp)
        {
            _SendComp = SendComp;
        }

        public void Update(GameTime gt)
        {

        }

        /// <summary>
        /// METHOD: Updates transform component
        /// </summary>
        /// <param name="gt"></param>
        /// <param name="comp"></param>
        public void Update(GameTime gt, Component.Component comp)
        {
            _components[0].Update(gt);
        }

        public void AddComponent(Component.Component comp)
        {
            if (!(comp is Component.Transform.Transform2D))
            {
                _SendComp(comp);
                _components.Add(comp);
            }
        }

        public T FindComponent<T>() where T : Component.Component
        {
            foreach (var comp in _components)
            {
                if (comp is T)
                {
                    return (T)comp;
                }
            }
            return null;
        }

        public void RemoveComponent<T>() where T : ECSEngine.Component.Component
        {
            foreach (var comp in _components)
            {
                _components.Remove(comp);
            }
        }

        /// <summary>
        /// METHOD: returns all the components that the entity contains
        /// </summary>
        /// <returns>A list of entitie's components</returns>
        public List<Component.Component> GetComponents()
        {
            return _components;
        }

        public void RemoveAllComponents()
        {
            throw new NotImplementedException();
        }

        private void CallComponentsUpdates(GameTime gt)
        {
            foreach (var comp in _components)
            {
                comp.Update(gt);
            }
        }

        public Vector2 GetPosition()
        {
            return _transform.position;
        }

        public float GetScale()
        {
            return _transform.scale;
        }

        public float GetRotationZ()
        {
            return _transform.rotationZ;
        }

        public void Transform(Vector2 step)
        {
            _transform.Translate(step);
        }
    }
}
