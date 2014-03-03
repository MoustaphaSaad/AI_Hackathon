using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Hack.Core
{
    interface IComponent
    {
        void Input();
        void Update();
        void Draw();
    }
}
