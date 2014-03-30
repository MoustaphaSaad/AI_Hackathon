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

namespace AI_Hack.Core
{
    public class VisualObject
    {
        //Object Attributes
        private Vector2 mPosition;

        //Getters & Setters
        public Vector2 Position
        {
            get { return mPosition; }
            set { mPosition = value; }
        }

        //Constructors
        public VisualObject(Vector2 pos)
        {
            mPosition = pos;
        }
        public VisualObject()
        {
            mPosition = new Vector2(0);
        }

        //Member Functions
        public void Move(Vector2 val)
        {
            mPosition += val;
        }
    }
}
