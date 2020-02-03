using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace ECSEngine.Component
{
    public interface IVDebuggable
    {
        void Draw(SpriteBatch sb);
    }
}
