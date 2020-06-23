using ECSGame.Component.Physics.Colliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSGame.Systems.ColiderSystem
{
    interface ICollisionSystem
    {
        /// <summary>
        /// METHOD: Removes a collider from collider list
        /// </summary>
        /// <param name="colliderItem">Collider which needs to be removed</param>
        void RemoveCollider(Collider colliderItem);

        /// <summary>
        /// Adds a collider to a list
        /// </summary>
        /// <param name="colliderItem">Collider which needs to be added</param>
        void AddCollider(Collider colliderItem);

        /// <summary>
        /// METHOD: returns a method into which a collider can be passed
        /// </summary>
        /// <returns>Returns a method which allows to add collider directly to a collider system</returns>
        Action<Collider> AddColliderAction();
    }
}
