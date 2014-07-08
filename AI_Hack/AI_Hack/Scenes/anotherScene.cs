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
using AI_Hack.Core;
using AI_Hack.Simulator;

namespace AI_Hack.Scenes
{
    class anotherScene : Observer.GameScene
    {

        public anotherScene(string n)
            : base(n)
        {
            clearColor = Color.CornflowerBlue;
            
        }

        public override void init()
        {
           
            base.init();
        }
        public override void setupScene()
        {
            base.setupScene();
        }
        public override void Input()
        {
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.S))
                uManager.SManager.setCurrent("TestScene");
            base.Input();
        }
        public override void Update(GameTime time)
        {
            UManager.Instance.WinHeight = 800;
            UManager.Instance.WinWidth = 600;
            base.Update(time);
        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
