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
    class GameObject : VisualObject,IComponent
    {
        //Object Attributes
        protected List<GameObject> childList;
        private IComponent RenderComp, BehaviourComp;

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

        public IComponent Renderer
        {
            get { return RenderComp; }
            set { if (value != null) RenderComp = value; }
        }

        public IComponent Behaviour
        {
            get { return BehaviourComp; }
            set { if (value != null) BehaviourComp = value; }
        }

        //Constructors
        public GameObject(Vector2 pos):base(pos){
            childList = new List<GameObject>();
            RenderComp = null;
            BehaviourComp = null;
        }
        public GameObject():base()
        {
            childList = new List<GameObject>();
            RenderComp = null;
            BehaviourComp = null;
        }

        //memberFunctions
        public void addChild(GameObject val)
        {
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
            foreach (GameObject obj in childList)
                obj.Draw();
            if(RenderComp != null)
                RenderComp.Draw();
        }
    }
}
