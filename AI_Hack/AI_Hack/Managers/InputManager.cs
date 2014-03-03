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

namespace AI_Hack.Managers
{
    class InputManager
    {
        private KeyboardState keyboard;
        private MouseState mouse;
        static InputManager instance = new InputManager();

        public MouseState Mouse
        {
            get { return mouse; }
        }
        public KeyboardState Keyboard
        {
            get { return keyboard; }
        }
        public static InputManager Instance
        {
            get
            {
                if (instance != null)
                    return instance;
                else
                {
                    instance = new InputManager();
                    return instance;
                }
            }
        }
        private InputManager()
        {
            keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
            
        }

        public void Update()
        {
            keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            mouse = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }
    }
}
