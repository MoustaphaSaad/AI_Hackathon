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
    public class Weapon : GameObject
    {
        // private GameObject parent;
        private Vector2 wrap;

        public Weapon(Vector2 position, Texture2D texture, GameObject parent, Vector2 wrap) :
            base(position)  // Weapon
        {
            this.parent = parent;
            this.wrap = wrap;
            Behaviour = new StuckBehavior(this);
            Renderer = new TankRenderer(texture, this);
        }
        public Weapon(Vector2 position, Texture2D texture, GameObject parent) : this(position, texture, parent, new Vector2(0, 0)) { }

        public Vector2 Wrap
        {
            get { return wrap; }
            set { wrap = value; }
        }
        public Vector2 GetDirection(float Angle)
        {
            Vector2 direction;
            direction.X = (float)Math.Cos(Angle);
            direction.Y = (float)Math.Sin(Angle);
            direction.Normalize();
            return direction;
        }
        public float Angle
        {
            get { return ((TankRenderer)Renderer).Angle; }
            set { ((TankRenderer)Renderer).Angle = value; }
        }
    }
}
