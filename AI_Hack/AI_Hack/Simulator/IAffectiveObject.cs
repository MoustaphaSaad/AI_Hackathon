using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using AI_Hack.Managers;
using AI_Hack.Core;

namespace AI_Hack.Simulator
{
    interface IAffectiveObject
    {

        void ExecuteEffect(Tank tank);

    }
}
