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
        MeinGun Gun;
        MeinTank tank;
        public TestScene(string n)
            : base(n)
        {
            clearColor = Color.CornflowerBlue;
            uManager.SManager.setCurrent(this);
            uManager.isMouseVisible = true;
        }

        public override void init()
        {
            Gun = new MeinGun();
            tank = new MeinTank();
            Gun.Position = new Vector2(0,0);
            tank.Position = new Vector2(300, 300);
            //this.addChild(tank);
            //this.addChild(Gun);
            Tank me = new Tank(new Vector2(200, 200), uManager.CManager.Load<Texture2D>("Tank//OrangeTank"), 100, Gun);
            this.addChild(me);
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
                Gun.Position = new Vector2(Gun.Position.X - 1, Gun.Position.Y);
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.D))
                Gun.Position = new Vector2(Gun.Position.X + 1, Gun.Position.Y);
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.S))
                Gun.Position = new Vector2(Gun.Position.X, Gun.Position.Y+1);
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.W))
                Gun.Position = new Vector2(Gun.Position.X, Gun.Position.Y-1);
            base.Input();
        }
        public override void Update()
        {

            if (Gun.isCollided(tank))
                Gun.Position = new Vector2(100, 100);
            base.Update();
        }
        public override void Draw()
        {
            x.Draw();
            base.Draw();
        }
    }
}
