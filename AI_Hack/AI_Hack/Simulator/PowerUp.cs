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
namespace AI_Hack.Simulator
{
    class PowerUp : AffectiveObject
    {


        public PowerUp(Vector2 position, Texture2D texture, float effectValue)
        {
            base.Position = position;
            this.effectValue = effectValue;
            Renderer = new DefaultRenderer(this, texture);
        }

    }
}
