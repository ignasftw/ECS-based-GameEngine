using System;
using System.Collections.Generic;
using System.Text;
using ECSGame.Component.Physics.Colliders;
using Microsoft.Xna.Framework;

namespace ECSGame.Systems.ColiderSystem
{
    public class CollisionSystem : ECSEngine.IUpdatable, ICollisionSystem
    {
        //DECLARE a float which will tell the the speed after collider bounces off, call it '_pushOutSpeed'
        private float _pushOutSpeed = 7;
        //DECLARE a float for delta time, call it '_fixedDeltaTime'
        private float _fixedDeltaTime = 0.01f;
        //DECLARE a float for timer, call it '_timer'
        private float _timer = 0;
        //DECLARE a list of Colliders which will contain all added colliders
        private List<Collider> _colliders = new List<Collider>();

        /// <summary>
        /// METHOD: Checks all colliders added to a scene
        /// </summary>
        /// <param name="gt"></param>
        public void Update(GameTime gt)
        {
            _timer += (float)gt.ElapsedGameTime.TotalSeconds;
            //IF the collision did not happen on this Delta Time
            if (_timer >= _fixedDeltaTime)
            {
                //Reset the timer
                _timer = 0;
                //Foreach collider in list
                foreach (Collider c1 in _colliders)
                {
                    //Foreach another collider in the list
                    foreach (Collider c2 in _colliders)
                    {
                        //Check if colliders are not the same and if they do not collide
                        if(c1 != c2 && DoCollide(c1, c2))
                        {
                            c1.Collide(0, PushSpeedVector(c1, c2));
                            c1.Collide(0, PushSpeedVector(c2, c1));
                        }
                    }
                }
            }
        }

        public bool DoCollide(Collider c1, Collider c2)
        {

            if (c1 is RectCollider)
            {
                if (c2 is RectCollider)
                {

                    return DoCollide((RectCollider)c1, (RectCollider)c2);
                }
            }

            return false;
        }
        public bool DoCollide(RectCollider c1, RectCollider c2)
        {
            Rectangle r1 = new Rectangle((int)c1.GetCenter().X, (int)c1.GetCenter().Y, (int)c1.GetDimensions().X, (int)c1.GetDimensions().Y);
            Rectangle r2 = new Rectangle((int)c2.GetCenter().X, (int)c2.GetCenter().Y, (int)c2.GetDimensions().X, (int)c2.GetDimensions().Y);


            return r1.Intersects(r2);
        }

        public Vector2 PushSpeedVector(Collider ECSEngine, Collider second)
        {

            if (ECSEngine is RectCollider)
            {
                if (second is RectCollider)
                {
                    return PushSpeedVector((RectCollider)ECSEngine, (RectCollider)second);
                }
            }

            throw new NotImplementedException();
        }

        public Vector2 PushSpeedVector(RectCollider ECSEngine, RectCollider second)
        {
            Vector2 pushV = new Vector2(0,second.GetTop()) - ECSEngine.GetCenter();
            pushV.Normalize();
            return new Vector2(0,pushV.Y) * _pushOutSpeed;
        }

        /// <summary>
        /// METHOD: Removes a collider from collider list
        /// </summary>
        /// <param name="colliderItem">Collider which needs to be removed</param>
        public void RemoveCollider(Collider colliderItem)
        {
            _colliders.Remove(colliderItem);
        }

        /// <summary>
        /// Adds a collider to a list
        /// </summary>
        /// <param name="colliderItem">Collider which needs to be added</param>
        public void AddCollider(Collider colliderItem)
        {
            _colliders.Add(colliderItem);
        }

        /// <summary>
        /// Adds a collider to a list
        /// </summary>
        /// <param name="colliderItem">Collider which needs to be added</param>
        public Action<Collider> AddColliderAction()
        {
            return AddCollider;
        }
    }
}
