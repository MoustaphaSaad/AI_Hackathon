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
        public Transform transform;

        //Getters & Setters
        

        //Constructors
        public VisualObject(Vector2 pos)
        {
            transform = new Transform();
            transform.position = pos;
        }
        public VisualObject()
        {
            transform = new Transform();
        }

        //Member Functions
        public void Move(Vector2 val)
        {
            transform.position += val;
        }
    }
}
