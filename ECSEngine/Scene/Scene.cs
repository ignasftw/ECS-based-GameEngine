﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Scene
{
    public class Scene : IECSActor
    {
        public List<Entity.Entity> entities;

        public Scene()
        {
            entities = new List<Entity.Entity>();
        }

        public void Update(GameTime gt)
        {
            CallEntitiesUpdates(gt);
            CallCSUpdate(gt);
        }

        public Entity.Entity AddEntity(ECSEngine.Entity.Entity entity)
        {
            entities.Add(entity);
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
