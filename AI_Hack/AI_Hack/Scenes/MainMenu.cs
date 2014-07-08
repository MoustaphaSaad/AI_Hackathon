using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI_Hack.Core;
using AI_Hack.Simulator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AI_Hack.Scenes
{
    class MainMenu:Observer.GameScene
    {
        public MainMenu(string n)
            : base(n)
        {
            uManager.SManager.setCurrent(this);
        }
        public override void setupScene(){
            Random rand = new Random(System.DateTime.Now.Millisecond);
            Tank t;
            for (int i = 0; i < 5; i++)
            {
                MeinGun g = new MeinGun();
                g.transform.position += new Vector2(2,5);
                t = new Tank(new Vector2(rand.Next(0, 800), rand.Next(0, 600)), uManager.CManager.Load<Texture2D>("Tank//OrangeTank"), 100,g);
                WanderBehaviour w = new WanderBehaviour(i*10);
                w.Parent = t;
                t.addBehaviour("wanderBehaviour", w);
                this.addChild(t);
            }



        }
    }
}
