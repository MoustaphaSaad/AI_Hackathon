using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI_Hack.Loader;
using AI_Hack.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AI_Hack.Simulator
{
    public class Sensor: Observer
    {
        private TileX[,] map;
        private int range;

        public TileX[,] Map
        {
            get
            {
                return map;
            }
        }
        protected override void Update(object msg)
        {
            map = (TileX[,])msg;
        }
    }
}
