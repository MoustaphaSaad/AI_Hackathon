using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AI_Hack.Core;
using AI_Hack.Managers;

namespace AI_Hack.Simulator
{
    class MeinTankRenderer:DefaultRenderer
    {
        public MeinTankRenderer(GameObject Tank):base(Tank,null)
        {
            Texture = UManager.Instance.CManager.Load<Texture2D>("Tank//OrangeTank");
        }
    }
}
