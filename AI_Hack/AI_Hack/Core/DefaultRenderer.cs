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
    class DefaultRenderer:ObjectRenderer
    {
        //Object Attributes
        protected Texture2D texture;
        protected Rectangle DestRect;
        protected Rectangle srcRect;

        //Getters & Setters
        public Texture2D Texture
        {
            get { return texture; }
            set {
                texture = value;
                if(parent !=null)
                    DestRect = new Rectangle((int)parent.transform.TransformedPosition.X, (int)parent.transform.TransformedPosition.X, texture.Width, texture.Height);
                srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
            }
        }

        //Constructors
        public DefaultRenderer(GameObject p, Texture2D tex)
        {
            parent = p;
            texture = tex;
            if (tex != null)
            {
                DestRect = new Rectangle((int)parent.transform.TransformedPosition.X, (int)parent.transform.TransformedPosition.X, texture.Width, texture.Height);
                srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
            }
        }
        public DefaultRenderer()
        {
            texture = null;
            parent = null;
            DestRect = new Rectangle();
            srcRect = new Rectangle();
        }

        //member functions
        public override void Draw()
        {
            UManager.Instance.Sprite.Begin();
            UManager.Instance.Sprite.Draw(texture, parent.transform.TransformedPosition, srcRect, Color.White,parent.transform.TransformedRotation,parent.transform.origin,parent.transform.TransformedScale,SpriteEffects.None,0f);
            UManager.Instance.Sprite.End();
        }

        public override Color[] getData()
        {
            Color[] d = new Color[texture.Width * texture.Height];
            texture.GetData(d);
            return d;
        }
        public override Rectangle getBoundingRectangle()
        {
            Vector2 pp = parent.transform.position;
            return new Rectangle((int)pp.X,(int) pp.Y, texture.Width, texture.Height);
        }
    }
}
