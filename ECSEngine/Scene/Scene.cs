using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Scene
{
    public class Scene : IUpdatable
    {
        //DECLARE a List of Entity.Entity, which will store entities
        private List<Entity.Entity> _entities;
        //DECLARE a dictionary of components, this allows updating components that are used, call it '_components'
        private Dictionary<ECSEngine.Component.Component, Type> _components;
        //DECLARE a List of Components which will have to be updated, call it '_systems'
        private List<ECSEngine.Component.Component> _systems;
        /// <summary>
        /// Property which will tell the amount of entities inside the scene, call it 'EntityCount'
        /// </summary>
        public int EntityCount { get {return _entities.Count; } }

        /// <summary>
        /// Constructor of the scene
        /// </summary>
        public Scene()
        {
            //Initialize empty List to store entities
            _entities = new List<Entity.Entity>();
            //Initialize empty List to store components which will have to be updated
            _systems = new List<ECSEngine.Component.Component>();
            //Initialize empty dictionary which will know which components have been used
            _components = new Dictionary<ECSEngine.Component.Component, Type>();
        }

        /// <summary>
        /// METHOD: which call updates on Components by type
        /// </summary>
        /// <param name="gt"></param>
        public virtual void Update(GameTime gt)
        {
            CallUpdatesByComponents(gt);
        }

        /// <summary>
        /// METHOD: add entity to a list while adding all components to a component list
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Entity.Entity AddEntity(ECSEngine.Entity.Entity entity)
        {
            //Send entitie's CollisionComponent to a CollisionSystem
            entity.SendComponent(AddComponentUpdate);
            _entities.Add(entity);
            return entity;
        }

        /// <summary>
        /// METHOD: Remove an entity from a list
        /// </summary>
        /// <param name="entity">entity which has to be removed</param>
        public void RemoveEntity(ECSEngine.Entity.Entity entity)
        {
            //Remove each component from a list that entity contains
            foreach (var comp in entity.GetComponents())
            {
                _components.Remove(comp);
            }
            _entities.Remove(entity);
        }

        /// <summary>
        /// METHOD: puts a new component into a list of unique components
        /// this allows only to update the components which have been added
        /// </summary>
        /// <param name="comp">Component</param>
        public void AddComponentUpdate(Component.Component comp)
        {
            _components.Add(comp, comp.GetType());
            //IF dictionary does not have any component add it to a dictionary
            if (_systems.Count > 0)
            {
                //Check if the dictionary includes component, if not add to a dictionary
                for (int i = 0; i < _systems.Count; i++)
                {
                    if(_systems[i].GetType() == comp.GetType())
                    {
                        return;
                    }
                }
                _systems.Add(comp);
            }
            else
            {
                _systems.Add(comp);
            }
        }

        /// <summary>
        /// Update all components by their type which should make better use of cache
        /// </summary>
        /// <param name="gt">Information about game time</param>
        public void CallUpdatesByComponents(GameTime gt)
        {
            //Call Update for each component in certain system
            foreach (Component.Component comp in _systems)
            {
                List<Component.Component> Components = GetComponents(comp);
                if (Components.Count > 0)
                {
                        for (int i = 0; i < Components.Count; i++)
                        {
                            Components[i].Update(gt);
                        }
                }
            }
        }

        /// <summary>
        /// METHOD: returns all components stored inside the class of a certain type
        /// </summary>
        /// <param name="type">Type of certain component to be returned</param>
        /// <returns></returns>
        public List<Component.Component> GetComponents(Component.Component type)
        {
            List<Component.Component> components = new List<Component.Component>();
            if (_components.ContainsValue(type.GetType()))
            {
                foreach(var comp in _components)
                {
                    if(comp.Key.GetType() == type.GetType())
                    components.Add(comp.Key);
                }
            }
            return components;
        }

        /// <summary>
        /// METHOD: call update method to individual entity
        /// </summary>
        /// <param name="gt"></param>
        private void CallEntitiesUpdates(GameTime gt)
        {
            foreach (Entity.Entity entt in _entities)
            {
                entt.Update(gt);
            }
        }
    }
}
