using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSEngine.Inputs 
{
    public class KeyboardInputHandler : IInputPublisher, IUpdatable
    {
        private List<IInputListener> _listeners;
        //private readonly IEventHandler<KeyboardEvent> keyboardInput; // Keyboard input handler.

        public KeyboardInputHandler()
        {
            _listeners = new List<IInputListener>();
        }

        public void Subscribe(IInputListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unsubscribe(IInputListener listener)
        {
            _listeners.Remove(listener);
        }

        /// <summary>
        /// METHOD: Updates the inputs
        /// </summary>
        /// <param name="gameTime">Snapshot of elapsed time values.</param>
        public void Update(GameTime gameTime)
        {
            try
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    foreach(var listener in _listeners)
                    {
                        listener.SpacebarIsDown();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured while pressing the 'spacebar' key in InputSystem class");
            }
        }
    }
}
