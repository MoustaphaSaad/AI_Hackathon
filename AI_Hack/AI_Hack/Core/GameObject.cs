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
    public class GameObject : VisualObject, IUpdatable,IDrawable

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
        public void removeChild(GameObject obj)
        {
            childList[childList.IndexOf(obj)] = null;
        }

        public virtual void Input()
        {
            for (int i = childList.Count - 1; i >= 0; i--)
            {
                if (childList[i] != null)
                    childList[i].Input();
            }
            if(BehaviourComp != null)
                BehaviourComp.Input();
            childList.RemoveAll(i=> i == null);
        }

        public virtual void Update()
        {
            for (int i = childList.Count - 1; i >= 0; i--)
            {
                if(childList[i]!=null)
                    childList[i].Update();
            }
            if (BehaviourComp != null)
                BehaviourComp.Update();
        }

        public virtual void Draw()
        {
            
            if(RenderComp != null)
                RenderComp.Draw();
            foreach (GameObject obj in childList)
            {
                if (obj != null)
                {
                    Vector2 pos = obj.Position + this.Position;
                    obj.Draw(pos);
                }
                
            }
        }
        public virtual void Draw(Vector2 position)
        {

            if (RenderComp != null)
                RenderComp.Draw(position);
            foreach (GameObject obj in childList)
            {
                if (obj != null)
                {
                    Vector2 pos = obj.Position + position;
                    obj.Draw(pos);
                }

            }
        }

        public bool isCollided(GameObject other)
        {
            Rectangle rectA = RenderComp.getBoundingRectangle();
            Rectangle rectB = other.RenderComp.getBoundingRectangle();

            Color[] dataA = RenderComp.getData();
            Color[] dataB = other.RenderComp.getData();

            int top = Math.Max(rectA.Top, rectB.Top);
            int bottom = Math.Min(rectA.Bottom, rectB.Bottom);
            int left = Math.Max(rectA.Left, rectB.Left);
            int right = Math.Min(rectA.Right, rectB.Right);


            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color A = dataA[(x - rectA.Left) + (y - rectA.Top) * rectA.Width];
                    Color B = dataB[(x - rectB.Left) + (y - rectB.Top) * rectB.Width];

                    if (A.A != 0 && B.A != 0)
                        return true;
                }
            }
            return false;
        }
    }
}
