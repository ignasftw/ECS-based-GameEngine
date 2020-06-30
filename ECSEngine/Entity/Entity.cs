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

        /// <summary>
        /// CONSTRUCTOR: setting initial entity values
        /// </summary>
        /// <param name="position">Vector2 Initial position of where it will be</param>
        /// <param name="scale">float which will tell how scaled object is '1.00' is normal, '2.00' is two times larger</param>
        /// <param name="name">string how the entity is called</param>
        /// <param name="tag">int which may be used to separate groups</param>
        public Entity(Vector2 position, float scale, string name = "Game Object", int tag = -1)
        {
            //Initialize component list
            _components = new List<Component.Component>();
            this._name = name;
            this._tag = tag;
            this._transform = new ECSEngine.Component.Transform.Transform2D(position, scale, this);
        }

        /// <summary>
        /// METHOD: set the delegate which will send a component to a list
        /// </summary>
        /// <param name="SendComp"></param>
        public void SendComponent(Action<Component.Component> SendComp)
        {
            _SendComp = SendComp;
        }

        /// <summary>
        /// METHOD: Updates transform component
        /// </summary>
        /// <param name="gt">Game Time which stores information about time</param>
        public void Update(GameTime gt)
        {
            //Component with '0' index should be transform
            _components[0].Update(gt);
        }

        /// <summary>
        /// METHOD: Adds a component to a component list
        /// </summary>
        /// <param name="comp"></param>
        public void AddComponent(Component.Component comp)
        {
            //IF the component is not a Transform2D
            if (!(comp is Component.Transform.Transform2D))
            {
                //Send a component to a list
                _SendComp(comp);
                //Store component inside an entity to group compoents by entities
                _components.Add(comp);
            }
        }

        /// <summary>
        /// METHOD: Finds a component type inside a list
        /// </summary>
        /// <typeparam name="T">Component type that has to be inside an entity</typeparam>
        /// <returns></returns>
        public T FindComponent<T>() where T : Component.Component
        {
            //For each component check if there is a component of a T type
            foreach (var comp in _components)
            {
                //IF component is found, return the component
                if (comp is T)
                {
                    return (T)comp;
                }
            }
            //Component was not found return null
            return null;
        }

        /// <summary>
        /// METHOD: Remove a component of a T type
        /// </summary>
        /// <typeparam name="T">Type of component that must be removed</typeparam>
        public void RemoveComponent<T>() where T : ECSEngine.Component.Component
        {
            //Cycle through all component to find unwanted component
            foreach (var comp in _components)
            {
                _components.Remove(comp);
            }
            //If there is no component is does not to be deleted
        }

        /// <summary>
        /// METHOD: returns all the components that the entity contains
        /// </summary>
        /// <returns>A list of entitie's components</returns>
        public List<Component.Component> GetComponents()
        {
            return _components;
        }

        /// <summary>
        /// METHOD: Get all components stored inside the entity
        /// </summary>
        /// <returns>A list of all components stored including Transform</returns>
        public List<Component.Component> RemoveAllComponents()
        {
            return _components;
        }

        /// <summary>
        /// METHOD: calls update method to components inside the entity
        /// This is to test regular update method
        /// </summary>
        /// <param name="gt"></param>
        private void CallComponentsUpdates(GameTime gt)
        {
            foreach (var comp in _components)
            {
                comp.Update(gt);
            }
        }

        /// <summary>
        /// METHOD: returns position of transform component
        /// </summary>
        /// <returns>Vector2, position of transform component</returns>
        public Vector2 GetPosition()
        {
            return _transform.GetPosition();
        }

        /// <summary>
        /// METHOD: returns scale of transform component
        /// </summary>
        /// <returns>float, scale of transform component</returns>
        public float GetScale()
        {
            return _transform.GetScale();
        }

        /// <summary>
        /// METHOD: returns rotationZ of transform component
        /// </summary>
        /// <returns>float, rotationZ of transform component</returns>
        public float GetRotationZ()
        {
            return _transform.GetRotationZ();
        }

        /// <summary>
        /// METHOD: adds vector2 to current position
        /// </summary>
        /// <param name="step">Vector2, Adding a position to a current position</param>
        public void Transform(Vector2 step)
        {
            _transform.Translate(step);
        }
    }
}
