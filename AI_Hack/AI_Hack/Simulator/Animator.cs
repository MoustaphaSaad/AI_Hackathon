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
using AI_Hack.Core;
namespace AI_Hack.Simulator
{
    enum AnimationState { BUSY, DONE }
    class Animator:ObjectBehaviour
    {
        Transform old;
        Transform target;
        AnimationState state;
        public Animator(GameObject p)
        {
            Parent = p;
            old = new Transform(p.transform);
            target = old;
            state = AnimationState.DONE;
        }
        public override System.Xml.XmlElement Encode()
        {
            return base.Encode();
        }
        public override void Decode(System.Xml.XmlElement obj)
        {
            base.Decode(obj);
        }
        public override void Input()
        {
            
        }
        public override void Update(GameTime time)
        {
            Parent.transform.position = Vector2.Lerp(Parent.transform.position, target.position, 0.025f);
            Parent.transform.rotation = MathHelper.Lerp(Parent.transform.rotation, target.rotation, 0.052f);
        }
        public void move(Vector2 newloc)
        {
            //setting the Work
            state = AnimationState.BUSY;
            target.position = newloc;
        }
        public void rotate(float rot)
        {
            state = AnimationState.BUSY;
            target.rotation = rot;
        }
    }
}
