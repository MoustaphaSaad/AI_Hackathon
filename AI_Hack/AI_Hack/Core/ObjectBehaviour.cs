using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AI_Hack.Core
{
    public abstract class ObjectBehaviour:IUpdatable, IXMLEncodable
    {
        //Object Attributes
        private GameObject parent;

        //Getters & Setters
        public GameObject Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        //Constructors
        public ObjectBehaviour(GameObject p)
        {
            parent = p;
        }

        public ObjectBehaviour()
        {
            parent = null;
        }
        //member functions
        public abstract void Input();
        public abstract void Update(GameTime time);
        public virtual XmlElement Encode()
        {
            return null;
        }
        public virtual void Decode(XmlElement obj)
        {

        }
    }
}
