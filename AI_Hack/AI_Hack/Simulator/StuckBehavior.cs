using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AI_Hack.Managers;
using AI_Hack.Core;
namespace AI_Hack.Simulator
{
    public class StuckBehavior : ObjectBehaviour
    {
        public StuckBehavior(GameObject parent) : base(parent) { }

        public override void Input()
        { }
        public override void Update()
        {
            Parent.Position = ((Weapon)Parent).Parent.Position + ((Weapon)Parent).Wrap;
        }

    }
}
