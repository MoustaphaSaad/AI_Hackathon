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
using System.IO;
using AI_Hack.Core;
using AI_Hack.Managers;

namespace AI_Hack.Simulator
{
    class Map:GameObject
    {
        int[,] data;
        int width, height, tileW, tileH;
        public int[,] Data
        {
            get { return data; }
        }

        public Map(int width, int height, int tileW, int tileH)
        {
            this.width = width;
            this.height = height;
            this.tileW = tileW;
            this.tileH = tileH;

            data = new int[height / tileH,width / tileW];
        }
        public void LoadMap(string path){
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            bool start = false;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line[0] == '#')
                    start = true;
                int i = 0;
                while (start)
                {
                    line = sr.ReadLine();
                    if (line[0] == '#' && start)
                    {
                     start = false;
                     break;
                    }
                    char[] dil = {' '};
                    string[] tokens = line.Split(dil);
                    for (int j = 0; j < tokens.Count(); j++)
                    {
                        data[i,j] = int.Parse(tokens[j]);
                    }
                    i++;
                }
            }

            sr.Close();
            fs.Close();
        }

    }
}
