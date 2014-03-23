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
using AI_Hack.Loader;

namespace AI_Hack.Scenes
{
    class TestScene:Scene
    {
        EnvironmentX x;
        public TestScene(string n)
            : base(n)
        {
            clearColor = Color.CornflowerBlue;
            uManager.SManager.setCurrent(this);
        }

        public override void init()
        {
            GameObject Gun = new GameObject(new Vector2(0, 0));
            Gun.Renderer = new TankGun(Gun);
            GameObject Tank = new GameObject(new Vector2(100, 100));
            Tank.Renderer = new TankRenderer(Tank);
            Tank.addChild(Gun);
            this.addChild(Tank);
            x = EnvironmentX.Load("Maps/ij.txt");
            base.init();
            uManager.WinHeight = 576;
            uManager.WinWidth = 768;
        }
        public override void setupScene()
        {
            base.setupScene();
        }
        public override void Input()
        {
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.A))
                uManager.SManager.setCurrent("anotherScene");
            base.Input();
        }
        public override void Update()
        {
            
            base.Update();
        }
        public override void Draw()
        {
            x.Draw();
            base.Draw();
        }
    }
}
