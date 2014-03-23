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
using AI_Hack.Managers;
using AI_Hack.Core;
using AI_Hack.Simulator;
using AI_Hack.Loader;

namespace AI_Hack.Loader
{
    struct Size{
        public int Width,Height;
        public Size(int x, int y)
        {
            Width = x;
            Height = y;
        }
    }
    class EnvironmentX:AI_Hack.Core.IDrawable
    {
        public Resource[,] Data { get; private set; }
        public string Name { get; private set; }
        public Size Tile { get; private set; }
        public Size Size { get; private set; }
        public Size TilesSize { get; private set; }

        public EnvironmentX(string n, Size t, Size s)
        {
            Name = n;
            Tile = t;
            Size = s;
            TilesSize = new Size((int)(s.Width / t.Width), (int)(s.Height / t.Height));
            Data = new Resource[TilesSize.Height, TilesSize.Width];
        }

        public virtual void Draw()
        {
            UManager.Instance.Sprite.Begin();
            for (int i = 0; i < TilesSize.Height; i++)
            {
                for (int j = 0; j < TilesSize.Width; j++)
                {
                    UManager.Instance.Sprite.Draw(Data[i, j].Texture, new Vector2(Tile.Width * j, Tile.Height * i), Color.White);
                }
            }
            UManager.Instance.Sprite.End();
        }


        public static EnvironmentX Load(string path)
        {
            EnvironmentX output = null ;
            List<Resource> srclst = new List<Resource>();
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string txt = sr.ReadToEnd();

            int rix = txt.IndexOf("$RESOURCES");
            if (rix!= -1)
            {
                int ssix = txt.IndexOf("{", rix);
                int seix = txt.IndexOf("}", ssix);
                string src = txt.Substring(ssix+1, seix-ssix-1);
                if (src.Count() > 0)
                {
                    int curix = 0;
                    while (curix!=-1)
                    {
                        curix = src.IndexOf("@ID", curix);
                        if (curix != -1)
                        {
                            int enix = src.IndexOf("\n", curix);
                            string id = src.Substring(curix, enix - curix - 1);
                            id = getVal(id);

                            curix = src.IndexOf("@NAME", curix);
                            enix = src.IndexOf("\n", curix);
                            string name = src.Substring(curix, enix - curix - 1);
                            name = getVal(name);

                            curix = src.IndexOf("@PATH", curix);
                            enix = src.IndexOf("\n", curix);
                            string pth = src.Substring(curix, enix - curix - 1);

                            string[] sps = path.Split(new char[] { '/' });
                            string rslt="";
                            for (int o = 0; o < sps.Count() - 1; o++)
                            {
                                rslt += sps[o] + "//";
                            }
                            pth = getVal(pth);

                            srclst.Add(new Resource(id,name,rslt+pth));

                        }
                        
                    }
                }
            }


            rix = txt.IndexOf("$MAPS");
            if (rix != -1)
            {
                int ssix = txt.IndexOf("{", rix);
                int seix = txt.IndexOf("}", ssix);
                string src = txt.Substring(ssix + 1, seix - ssix - 1);
                if (src.Count() > 0)
                {
                    int curix = 0;
                    while (curix != -1)
                    {
                        curix = src.IndexOf("@NAME", curix);
                        if (curix != -1)
                        {
                            int enix = src.IndexOf("\n", curix);
                            string name = src.Substring(curix, enix - curix - 1);
                            name = getVal(name);

                            curix = src.IndexOf("@TILE_X", curix);
                            enix = src.IndexOf("\n", curix);
                            string tx = src.Substring(curix, enix - curix - 1);
                            tx = getVal(tx);

                            curix = src.IndexOf("@TILE_Y", curix);
                            enix = src.IndexOf("\n", curix);
                            string ty = src.Substring(curix, enix - curix - 1);
                            ty = getVal(ty);

                            curix = src.IndexOf("@WIDTH", curix);
                            enix = src.IndexOf("\n", curix);
                            string w = src.Substring(curix, enix - curix - 1);
                            w = getVal(w);

                            curix = src.IndexOf("@HEIGHT", curix);
                            enix = src.IndexOf("\n", curix);
                            string h = src.Substring(curix, enix - curix - 1);
                            h = getVal(h);

                            curix = src.IndexOf("#DATA", curix);
                            enix = src.IndexOf("#END_DATA", curix);
                            string d = src.Substring(curix, enix - curix - 1);

                            StringReader sd = new StringReader(d);
                            output = new EnvironmentX(name,new Size(int.Parse(tx),int.Parse(ty)),new Size(int.Parse(w),int.Parse(h)));
                            string l;
                            l = sd.ReadLine();
                            int i=0;
                            int j=0;
                            while ((l=sd.ReadLine())!=null)
                            {
                                string[] koko = l.Split(new char[]{' '});
                                for(int k=0;k<koko.Count();k++){
                                    if (j == output.TilesSize.Width)
                                    {
                                        i++;
                                        j = 0;
                                    }
                                    int ijx = int.Parse(koko[k]);
                                    output.Data[i, j] = getRes(ijx,srclst);
                                    j++;
                                }
                            
                            }
                            sd.Close();
                            

                        }

                    }
                }
            }
            

            sr.Close();
            fs.Close();
            return output;
        }
        private static Resource getRes(int id,List<Resource> lst)
        {
            Resource output = null ;
            for (int i = 0; i < lst.Count; i++)
            {
                if (int.Parse(lst[i].ID) == id)
                {
                    output = lst[i];
                    break;
                }
            }
            return output;
        }
        private static string getVal(string line)
        {
            string output = "";
            bool strt = false;
            for(int i=0;i<line.Count();i++){
                if (strt && line[i] != '\n' && line[i] != '\t' && line[i] != '\r' && line[i] != ' ')
                {
                    output += line[i];
                }
                if (line[i] == '=')
                    strt = true;
            }
            return output;
        }
    }
}
