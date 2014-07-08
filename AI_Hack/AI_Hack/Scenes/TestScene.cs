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
    class TestScene:Observer.GameScene
    {
        MeinGun Gun;
        Tank me;
        public TestScene(string n)
            : base(n)
        {
            clearColor = Color.CornflowerBlue;
            //uManager.SManager.setCurrent(this);
            uManager.isMouseVisible = true;
        }

        public override void init()
        {
            Gun = new MeinGun();
            Tileset = EnvironmentX.Load("Maps/ij.txt");
            me = new Tank(Tileset.getTilePosition(5, 5), uManager.CManager.Load<Texture2D>("Tank//OrangeTank"), 100, Gun);
            this.Attach(me.sensor);
            Vector2 tileIX = Tileset.PositionToTileIndex(me.transform.position.X, me.transform.position.Y);
            this.addChild(me);
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
                me.transform.position = new Vector2(me.transform.position.X - 1, me.transform.position.Y);
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.D))
                me.transform.position = new Vector2(me.transform.position.X + 1, me.transform.position.Y);
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.S))
                me.transform.position = new Vector2(me.transform.position.X, me.transform.position.Y + 1);
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.W))
                me.transform.position = new Vector2(me.transform.position.X, me.transform.position.Y - 1);
            base.Input();
        }
        public override void Update(GameTime time)
        {
            base.Update(time);
            var map = this.getMap();
        }
        public override void Draw()
        {
            Tileset.Draw();
            base.Draw();
        }
    }
}
