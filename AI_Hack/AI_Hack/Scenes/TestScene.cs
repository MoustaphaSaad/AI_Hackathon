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
    class TestScene:Scene
    {
        
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

            Map mp = new Map(UManager.Instance.WinWidth, UManager.Instance.WinHeight, 48, 48);
            mp.LoadMap("Maps/Map.txt");
            base.init();
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
            base.Draw();
        }
    }
}
