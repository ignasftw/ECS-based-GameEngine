using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSEngine.Inputs
{
    public interface IInputPublisher
    {
        /// <summary>
        /// METHOD: listener subscribes to this publisher
        /// </summary>
        /// <param name="listener">Object which requires knowledge of the input</param>
        void Subscribe(IInputListener listener);

        /// <summary>
        /// METHOD: removes the listener from the list
        /// </summary>
        /// <param name="listener">Object which does not require knowledge of the input anymore</param>
        void Unsubscribe(IInputListener listener);

    }
}
