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
using AI_Hack.Managers;

namespace AI_Hack.Core
{
    class Scene:GameObject
    {
        //Class Attributes
        protected Color clearColor;
        protected bool done;
        protected UManager uManager;
        string name;

        //Getters & Setters
        public Color ClearColor
        {
            get { return clearColor; }
            set { clearColor = value; }
        }
        public bool isDone
        {
            get { return done; }
        }
        public string Name
        {
            get { return name; }
        }
        
        //Constructors
        public Scene(string n)
            : base()
        {
            clearColor = Color.CornflowerBlue;
            done = false;
            name = n;
            uManager = UManager.Instance;
        }

        //member functions
        public virtual void init()
        {
            done = true;
        }
        public virtual void setupScene()
        {
        }
    }
}
