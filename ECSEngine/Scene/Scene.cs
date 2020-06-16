using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Scene
{
    public class Scene : IUpdatable
    {
        public List<Entity.Entity> entities;
        private Dictionary<Type, ECSEngine.Component.Component> components;
        public List<ECSEngine.Component.Component> _components;


        public Scene()
        {
            entities = new List<Entity.Entity>();

            //Initialize empty distionary to store components
            //_components = new Dictionary<Type, ECSEngine.Component.Component>();
            _components = new List<Component.Component>();
        }

        public void Update(GameTime gt)
        {
            CallEntitiesUpdates(gt);
            CallCSUpdate(gt);
        }

        public Entity.Entity AddEntity(ECSEngine.Entity.Entity entity)
        {
            entities.Add(entity);

            //foreach (var pair in entity.components)
            //{
            //    List<ECSEngine.Component.Component> componentGroup = null;
            //    if (_componentGroups.TryGetValue(pair.Key, out componentGroup) == false)
            //    {
            //        componentGroup = new List<ECSEngine.Component.Component>();
            //        _componentGroups.Add(pair.Key, componentGroup);
            //    }
            //    componentGroup.Add(pair.Value);
            //}

            return entity;
        }

        public void RemoveEntity(ECSEngine.Entity.Entity entity)
        {
            entities.Remove(entity);
        }

        private void CallEntitiesUpdates(GameTime gt)
        {
            foreach (Entity.Entity entt in entities)
            {
                entt.Update(gt);
            }
        }

        private void CallCSUpdate(GameTime gt)
        {
            ECSEngine.Systems.ColiderSystem.CS.Update(gt);
        }
    }
}
