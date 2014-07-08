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
using System.Xml;
using AI_Hack.Simulator;
namespace AI_Hack.Core
{
    public class GameObject : VisualObject, IUpdatable,IDrawable,IXMLEncodable

    {
        //Object Attributes
        protected List<GameObject> childList;
        private ObjectRenderer RenderComp;
        private Dictionary<string,ObjectBehaviour> Behaviours;
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
        public GameObject Parent
        {
            get { return parent; }
            set { parent = value; }
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

        //Constructors
        public GameObject(Vector2 pos):base(pos){
            childList = new List<GameObject>();
            RenderComp = null;
            Behaviours = new Dictionary<string, ObjectBehaviour>();
            parent = null;
            Behaviours.Add("Animator", new Animator(this));
        }
        public GameObject()
            : base()
        {
            childList = new List<GameObject>();
            RenderComp = null;
            Behaviours = new Dictionary<string, ObjectBehaviour>();
            parent = null;
            Behaviours.Add("Animator", new Animator(this));
        }

        //memberFunctions
        public virtual void addChild(GameObject val)
        {
            val.parent = this;
            val.transform.parent = this.transform;
            childList.Add(val);
        }
        public void removeChild(GameObject obj)
        {
            obj.transform.parent = null;
            childList[childList.IndexOf(obj)] = null;
        }

        public virtual void Input()
        {
            for (int i = childList.Count - 1; i >= 0; i--)
            {
                if (childList[i] != null)
                    childList[i].Input();
            }
            foreach (var behaviour in Behaviours)
            {
                behaviour.Value.Input();
            }
            childList.RemoveAll(i=> i == null);
        }

        public virtual void Update(GameTime time)
        {
            for (int i = childList.Count - 1; i >= 0; i--)
            {
                if(childList[i]!=null)
                    childList[i].Update(time);
            }
            foreach (var behaviour in Behaviours)
            {
                behaviour.Value.Update(time);
            }
        }

        public virtual void Draw()
        {
            
            if(RenderComp != null)
                RenderComp.Draw();
            foreach (GameObject obj in childList)
            {
                if (obj != null)
                {
                    obj.Draw();
                }
                
            }
        }
        public void addBehaviour(string name,ObjectBehaviour b){
            Behaviours.Add(name, b);
        }
        public ObjectBehaviour getBehaviour(string name)
        {
            if (Behaviours.ContainsKey(name))
                return Behaviours[name];
            else
                return null;
        }
        public void move(Vector2 location)
        {
            Animator a = getBehaviour("Animator") as Animator;
            a.move(location);
        }
        public void rotate(float rotate)
        {
            Animator a = getBehaviour("Animator") as Animator;
            a.rotate(rotate);
        }
        public XmlElement Encode()
        {
            /*
            XmlElement obj = new XmlElement();
            obj.SetAttribute("Type", "GameObject");
            obj.SetAttribute("Position", transform.position.ToString());
            obj.SetAttribute("Rotation", transform.rotation.ToString());
            obj.SetAttribute("Scale", transform.scale.ToString());
            if (RenderComp != null)
                obj.AppendChild(RenderComp.Encode());
            if (BehaviourComp != null)
                obj.AppendChild(BehaviourComp.Encode());
            return obj;*/
            return null;
        }
        public virtual void Decode(XmlElement obj)
        {

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
