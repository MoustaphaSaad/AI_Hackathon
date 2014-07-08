using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI_Hack.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AI_Hack.Simulator
{
    class WanderBehaviour:ObjectBehaviour
    {
        bool moved = false;
        public WanderBehaviour(int seed){

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
            //throw new NotImplementedException();
        }
        public override void Update(GameTime time)
        {

        }

    }
}
