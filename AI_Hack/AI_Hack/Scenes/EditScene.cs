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
    class EditScene : Observer.GameScene
    {
        private char current;
        public EditScene(string n):base(n)
        {
            clearColor = Color.CornflowerBlue;
            
            uManager.isMouseVisible = true;
            uManager.WinHeight = 600;
            uManager.WinWidth = 800;
            current = ' ';
            //uManager.SManager.setCurrent(this);
        }
        public override void Input()
        {
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.G))
                current = 'g';
            if (InputManager.Instance.Keyboard.IsKeyDown(Keys.T))
                current = 't';
            
            if (InputManager.Instance.Mouse.LeftButton == ButtonState.Pressed&&!InputManager.Instance.Keyboard.IsKeyDown(Keys.LeftShift) && uManager.Game.IsActive)
            {
                if (current == 't')
                {
                    MeinTank x = new MeinTank();
                    x.addBehaviour("editBehaviour",new MeinEditBehaviour(x));
                    x.transform.position = new Vector2(InputManager.Instance.Mouse.X, InputManager.Instance.Mouse.Y);
                    this.addChild(x);
                }
                if (current == 'g')
                {
                    MeinGun x = new MeinGun();
                    x.addBehaviour("editBehaviour", new MeinEditBehaviour(x));
                    x.transform.position = new Vector2(InputManager.Instance.Mouse.X, InputManager.Instance.Mouse.Y);
                    this.addChild(x);
                }
                
            }
            
            base.Input();
        }
    }
}
