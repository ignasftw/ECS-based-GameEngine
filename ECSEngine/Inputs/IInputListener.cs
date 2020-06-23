using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSEngine.Inputs
{
    public interface IInputListener
    {
        /// <summary>
        /// METHOD: notifies the listener that the spacebar was pressed
        /// </summary>
        void SpacebarIsDown();
    }
}
