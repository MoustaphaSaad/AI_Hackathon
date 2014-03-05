using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Hack.Core
{
    class ObjectBehaviour:IComponent
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
        public virtual void Input()
        {

        }

        public virtual void Update()
        {

        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
