﻿using System;
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
    class FireBullet : GameObject, IAffectiveObject
    {
        public Vector2 velocity;
        public Vector2 initialPosition;
        public Vector2 direction;
        public float range;
        public float effectValue;



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


        public override void Update(GameTime time)
        {
            Parent.transform.position = ((FireBullet)Parent).Parent.transform.position + ((FireBullet)Parent).velocity;
        }
        public void ExecuteEffect(Tank tank)
        {
            tank.EffectHealth(effectValue);
        }


    }
}
