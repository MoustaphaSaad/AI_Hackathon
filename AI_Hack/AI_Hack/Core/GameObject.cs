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
    class GameObject : VisualObject, IUpdatable,IDrawable

    {
        //Object Attributes
        protected List<GameObject> childList;
        private ObjectRenderer RenderComp;
        private ObjectBehaviour BehaviourComp;
        protected GameObject parent;

        //Getters & Setters
        public GameObject this[int ix]{
            get
            {
                if (ix < childList.Count)
                    return childList[ix];
                else
                    return null;
            }
        }

        public int ChildCount
        {
            get { return childList.Count; }
        }

        public ObjectRenderer Renderer
        {
            get { return RenderComp; }
            set { if (value != null) RenderComp = value; }
        }

        public ObjectBehaviour Behaviour
        {
            get { return BehaviourComp; }
            set { if (value != null) BehaviourComp = value; }
        }

        public GameObject Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        //Constructors
        public GameObject(Vector2 pos):base(pos){
            childList = new List<GameObject>();
            RenderComp = null;
            BehaviourComp = null;
            parent = null;
        }
        public GameObject():base()
        {
            childList = new List<GameObject>();
            RenderComp = null;
            BehaviourComp = null;
            parent = null;
        }

        //memberFunctions
        public void addChild(GameObject val)
        {
            val.parent = this;
            childList.Add(val);
        }

        public virtual void Input()
        {
            foreach (GameObject obj in childList)
                obj.Input();
            if(BehaviourComp != null)
                BehaviourComp.Input();
        }

        public virtual void Update()
        {
            foreach (GameObject obj in childList)
                obj.Update();
            if (BehaviourComp != null)
                BehaviourComp.Update();
        }

        public virtual void Draw()
        {
            
            if(RenderComp != null)
                RenderComp.Draw();
            foreach (GameObject obj in childList)
            {
                Vector2 pos = obj.Position + this.Position;
                obj.Draw(pos);
                
            }
        }
        public virtual void Draw(Vector2 position)
        {

            if (RenderComp != null)
                RenderComp.Draw(position);
            foreach (GameObject obj in childList)
            {
                Vector2 pos = obj.Position +position;
                obj.Draw(pos);

            }
        }
    }
}
