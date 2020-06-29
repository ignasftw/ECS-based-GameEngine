using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Scene
{
    public class Scene : IUpdatable
    {
        public List<Entity.Entity> _entities;
        public Dictionary<ECSEngine.Component.Component, Type> _components;
        private List<ECSEngine.Component.Component> _systems;

        public Scene()
        {
            _entities = new List<Entity.Entity>();

            //Initialize empty distionary to store components
            _systems = new List<ECSEngine.Component.Component>();
            _components = new Dictionary<ECSEngine.Component.Component, Type>();
        }

        public virtual void Update(GameTime gt)
        {
            //CallUpdatesByComponents(gt);
            CallEntitiesUpdates(gt);
        }

        public Entity.Entity AddEntity(ECSEngine.Entity.Entity entity)
        {
            //Send entitie's CollisionComponent to a CollisionSystem
            entity.SendComponent(AddComponentUpdate);
            _entities.Add(entity);
            return entity;
        }

        public void RemoveEntity(ECSEngine.Entity.Entity entity)
        {
            //entity.RemoveAllComponents();
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
            //Console.WriteLine("Component was added " + comp.ToString());
            _components.Add(comp, comp.GetType());
            if (_systems.Count > 0)
            {
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

        public void CallUpdatesByComponents(GameTime gt)
        {
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

        private void CallEntitiesUpdates(GameTime gt)
        {
            foreach (Entity.Entity entt in _entities)
            {
                entt.Update(gt);
            }
        }
    }
}
