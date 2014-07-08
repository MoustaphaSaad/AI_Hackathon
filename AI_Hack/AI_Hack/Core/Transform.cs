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


namespace AI_Hack.Core
{
    public class Transform
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;
        public Transform parent;
        public Vector2 origin;


        public Vector2 TransformedPosition
        {
            get
            {
                if (parent == null)
                    return position;
                else
                    return position + parent.position;
            }
        }
        public float TransformedRotation
        {
            get
            {
                if (parent == null)
                    return rotation;
                else
                    return rotation + parent.rotation;
            }
        }
        public Vector2 TransformedScale
        {
            get
            {
                if (parent == null)
                    return scale;
                else
                    return parent.scale;
            }
        }
        public Transform()
        {
            position = new Vector2();
            origin = new Vector2(0, 0);
            rotation = 0;
            scale = new Vector2(1, 1) ;
            parent = null;
        }
        public Transform(Transform t)
        {
            position = new Vector2(t.position.X,t.position.Y);
            origin = new Vector2(t.origin.X, t.origin.Y);
            rotation = t.rotation;
            scale = new Vector2(t.scale.X, t.scale.Y);
            parent = t.parent;
        }
        public static float DegToRad(float deg){
            return deg / 57.2957795f;
        }
        public static float RadToDeg(float rad)
        {
            return rad * 57.2957795f;
        }
    }
}
