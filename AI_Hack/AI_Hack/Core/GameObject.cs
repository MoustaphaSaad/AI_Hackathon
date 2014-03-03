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
    class GameObject : VisualObject
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

        public virtual void input()
        {
            foreach (GameObject obj in childList)
                obj.input();
            if(BehaviourComp != null)
                BehaviourComp.Input();
        }

        public virtual void update()
        {
            foreach (GameObject obj in childList)
                obj.update();
            if (BehaviourComp != null)
                BehaviourComp.Update();
        }

        public virtual void draw()
        {
            foreach (GameObject obj in childList)
                obj.draw();
            if(RenderComp != null)
                RenderComp.Draw();
        }
    }
}
