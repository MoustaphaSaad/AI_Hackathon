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
    class ObjectRenderer:IComponent
    {
        //Object Attributes
        protected Texture2D texture;
        protected Rectangle DestRect;
        protected Rectangle srcRect;
        protected GameObject parent;

        //Getters & Setters
        public Texture2D Texture
        {
            get { return texture; }
            set {
                texture = value;
                if(parent !=null)
                    DestRect = new Rectangle((int)parent.Position.X, (int)parent.Position.X, texture.Width, texture.Height);
                srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
            }
        }

        public GameObject Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        //Constructors
        public ObjectRenderer(GameObject p, Texture2D tex)
        {
            parent = p;
            texture = tex;
            DestRect = new Rectangle((int)parent.Position.X, (int)parent.Position.X, texture.Width, texture.Height);
            srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        public ObjectRenderer()
        {
            texture = null;
            parent = null;
            DestRect = new Rectangle();
            srcRect = new Rectangle();
        }

        //member functions
        public virtual void Draw()
        {
            UManager.Instance.Sprite.Begin();
            UManager.Instance.Sprite.Draw(texture, DestRect, srcRect, Color.White);
            UManager.Instance.Sprite.End();
        }
        public void Input()
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
