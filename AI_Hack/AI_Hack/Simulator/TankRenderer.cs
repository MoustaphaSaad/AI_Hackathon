using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI_Hack.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using AI_Hack.Managers;

namespace AI_Hack.Simulator
{
    public class TankRenderer : ObjectRenderer
    {
        // private GameObject parent;
        private List<Texture2D> textures;
        private int index;
        private float angle;
        public TankRenderer(Texture2D texture, GameObject parent)
            : base(parent)
        {
            textures = new List<Texture2D>();
            textures.Add(texture);
            index = 0;
            angle = 0;
            //  this.parent = parent;
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public float Angle
        {
            get { return Angle; }
            set { Angle = value; }
        }
        public void AddTexture(Texture2D tex)
        {
            textures.Add(tex);
        }
        public Texture2D GetTexture(int i)
        {
            return textures[i];
        }
        public List<Texture2D> GetTextures()
        {
            return textures;
        }
        public void SetTextures(List<Texture2D> tex, int start = 0)
        {
            for (int i = start; i < textures.Count; ++i)
                AddTexture(textures[i]);
        }

        public override void Draw(Vector2 position) // if u wanna use it , but i brefer to send the wrap once and draw accordin to it
        {
            // Draw();
            UManager.Instance.Sprite.Begin();

            //  DestRect = new Rectangle((int)parent.Position.X, (int)parent.Position.X, texture.Width, texture.Height);
            Rectangle srcRect = new Rectangle(0, 0, textures[index].Width, textures[index].Height);
            UManager.Instance.Sprite.Draw(textures[index], position, srcRect, Color.White, angle,
                               new Vector2(0, 0), 1, SpriteEffects.None, 0.0f);

            UManager.Instance.Sprite.End();
        }
        public override void Draw()
        {
            UManager.Instance.Sprite.Begin();

            //  DestRect = new Rectangle((int)parent.Position.X, (int)parent.Position.X, texture.Width, texture.Height);
            Rectangle srcRect = new Rectangle(0, 0, textures[index].Width, textures[index].Height);
            UManager.Instance.Sprite.Draw(textures[index], parent.Position, srcRect, Color.White, angle,
                               new Vector2(0, 0), 1, SpriteEffects.None, 0.0f);

            UManager.Instance.Sprite.End();

        }
        public override Rectangle getBoundingRectangle()
        {
            return new Rectangle((int)parent.Position.X, (int)parent.Position.Y, textures[index].Width, textures[index].Height);
        }
        public override Color[] getData()
        {
            Color[] d = new Color[textures[index].Width * textures[index].Height];
            textures[index].GetData(d);
            return d;
        }
    }
}
