using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AI_Hack.Loader;
using AI_Hack.Managers;


namespace AI_Hack.Loader
{
    public class Resource
    {
        public string ID { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public Texture2D Texture { get; private set; }

        public Resource(string id, string n, string p)
        {
            ID = id;
            Name = n;
            Path = p;
            var fs = new FileStream(Path, FileMode.Open);
            Texture = Texture2D.FromStream(UManager.Instance.GXManager.GraphicsDevice, fs);
            fs.Close();
        }


    }
}
