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
    public class Tank : GameObject
    {
        private float health;
        private Sensor msensor;
        public Sensor sensor
        {
            get { return msensor; }
        }
        public Tank(Vector2 position, Texture2D texture, float health, GameObject Gun) // Weapon
            : base(position)
        {
            addChild(Gun);
            this.health = health;
            Renderer = new TankRenderer(texture, this);
            msensor = new Sensor();
        }
        public void SetBehavior(ObjectBehaviour Brain)
        {
            Behaviour = Brain;
        }
        public Tank(Vector2 position, List<Texture2D> textures, float health, GameObject Gun)
            : this(position, textures[0], health, Gun)
        {
            ((TankRenderer)Renderer).SetTextures(textures, 1);
            msensor = new Sensor();
        }
        public GameObject Gun
        {
            get { return (GameObject)childList[0]; }
            set { childList[0] = value; }
        }
        public void EffectHealth(float val)
        {
            health += val;
        }

    }
}
