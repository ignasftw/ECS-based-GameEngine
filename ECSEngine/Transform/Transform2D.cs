using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine.Component.Transform
{
    public class Transform2D : Component
    {
        //DECLARE a Vector2 which tells the coordinates of an object, call it '_position'
        private Vector2 _position;
        //DECLARE a float which will tell the scale of the object, normal is '1.00' scaled two times is '2.00', call it '_scale'
        private float _scale;
        //DECLARE a float which tells how the object is rotated in Z axis, call it '_rotationZ'
        private float _rotationZ;


        /// <summary>
        /// CONSTRUCTOR: Initializes Transform2D component
        /// </summary>
        /// <param name="pos">Initial position of where the object should be</param>
        /// <param name="scale">Initial scale of an object</param>
        /// <param name="attachee">The entity which comtains this component</param>
        /// <param name="rot">Initial rotation in Z axis of an object</param>
        public Transform2D(Vector2 pos, float scale, Entity.Entity attachee, float rot = 0)
            :base(attachee)
        {
            this._position = pos;
            this._scale = scale;
            this._rotationZ = rot;
        }

        /// <summary>
        /// METHOD: Adds coordinates to current position
        /// </summary>
        /// <param name="distance">A step which adds coordnatates to current ones</param>
        public void Translate(Vector2 distance)
        {
            _position += distance;
        }

        /// <summary>
        /// METHOD: return current position of the transform component
        /// </summary>
        /// <returns>Vector2 coordinates</returns>
        public Vector2 GetPosition()
        {
            return _position;
        }

        /// <summary>
        /// METHOD: return current rotation of the transform component
        /// </summary>
        /// <returns>float rotation angle</returns>
        public float GetRotationZ()
        {
            return _rotationZ;
        }

        /// <summary>
        /// METHOD: return current scale of the transform component
        /// </summary>
        /// <returns>float scale of the object '1.00' is regular '0.5' is two times smaller</returns>
        public float GetScale()
        {
            return _scale;
        }

        public override void Update(GameTime gt)
        {

        }
    }
}
