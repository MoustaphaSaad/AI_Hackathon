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

namespace AI_Hack.Simulator
{
    class MeinEditBehaviour: ObjectBehaviour
    {
        bool drag;
        public MeinEditBehaviour(GameObject parent):base(parent)
        {
            drag = false;
        }
        public override void Input()
        {
            if (InputManager.Instance.Mouse.RightButton == ButtonState.Pressed)
                if (InputManager.Instance.Mouse.X >= Parent.transform.position.X && InputManager.Instance.Mouse.X <= Parent.transform.position.X + Parent.Renderer.getBoundingRectangle().Width)
                    if (InputManager.Instance.Mouse.Y >= Parent.transform.position.Y && InputManager.Instance.Mouse.Y <= Parent.transform.position.Y + Parent.Renderer.getBoundingRectangle().Height)
                        Parent.Parent.removeChild(Parent);

            if (InputManager.Instance.Mouse.LeftButton == ButtonState.Pressed && InputManager.Instance.Keyboard.IsKeyDown(Keys.LeftShift))
                if (InputManager.Instance.Mouse.X >= Parent.transform.position.X && InputManager.Instance.Mouse.X <= Parent.transform.position.X + Parent.Renderer.getBoundingRectangle().Width)
                    if (InputManager.Instance.Mouse.Y >= Parent.transform.position.Y && InputManager.Instance.Mouse.Y <= Parent.transform.position.Y + Parent.Renderer.getBoundingRectangle().Height)
                        drag = true;
            if (InputManager.Instance.Mouse.LeftButton == ButtonState.Released)
                drag = false;

        }
        public override void Update()
        {
            if (drag)
            {
                Parent.transform.position = new Vector2(InputManager.Instance.Mouse.X, InputManager.Instance.Mouse.Y);
            }
        }
    }
}
