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

namespace AI_Hack.Core
{
    public abstract class ObjectRenderer:IDrawable
    {
        //Object Attributes
        protected GameObject parent;

        //Getters & Setters

        public GameObject Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        //Constructors
        public ObjectRenderer(GameObject p)
        {
            parent = p;
        }
        public ObjectRenderer()
        {
            parent = null;
        }

        //member functions
        public abstract void Draw();
        public abstract void Draw(Vector2 position);

        public abstract Color[] getData();
        public abstract Rectangle getBoundingRectangle();
    }
}
