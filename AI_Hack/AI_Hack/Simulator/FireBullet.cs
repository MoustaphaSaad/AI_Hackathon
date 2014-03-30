using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using AI_Hack.Managers;
using AI_Hack.Core;
namespace AI_Hack.Simulator
{
    class FireBullet : AffectiveObject
    {
        public Vector2 velocity;
        public Vector2 initialPosition;
        public Vector2 direction;
        public float range;




        public FireBullet(Vector2 initialPosition, Vector2 direction, float range, Vector2 velocity, GameObject parent, Texture2D texture, float effectValue)
        {
            this.parent = parent;
            this.direction = direction;
            this.range = range;
            this.initialPosition = initialPosition;
            this.velocity = velocity;
            this.effectValue = effectValue;


            Renderer = new DefaultRenderer(this, texture);



        }


        public override void Update()
        {
            Parent.Position = ((FireBullet)Parent).Parent.Position + ((FireBullet)Parent).velocity;
        }

    }
}
