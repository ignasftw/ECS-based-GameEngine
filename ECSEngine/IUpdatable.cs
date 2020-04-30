using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace ECSEngine
{
    public interface IUpdatable
    {
        void Update(GameTime gt);
    }
}
