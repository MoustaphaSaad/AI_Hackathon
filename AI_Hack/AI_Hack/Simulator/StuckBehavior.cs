﻿using System;
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
using AI_Hack.Managers;
using AI_Hack.Core;
namespace AI_Hack.Simulator
{
    public class StuckBehavior : ObjectBehaviour
    {
        public StuckBehavior(GameObject parent) : base(parent) { }

        public override void Input()
        { }
        public override void Update(GameTime time)
        {
            Parent.transform.position = ((Weapon)Parent).Parent.transform.position + ((Weapon)Parent).Wrap;
        }

    }
}
