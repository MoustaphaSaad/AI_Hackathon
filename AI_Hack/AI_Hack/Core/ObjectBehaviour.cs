using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Hack.Core
{
    public abstract class ObjectBehaviour:IUpdatable
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
        public abstract void Update();
    }
}
