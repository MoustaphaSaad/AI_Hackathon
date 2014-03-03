using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI_Hack.Core;

namespace AI_Hack.Managers
{
    class SceneManager
    {
        private Scene current;
        private Dictionary<string, Scene> Scenes;
        public Scene Current
        {
            get { return current; }
        }
        public SceneManager()
        {
            current = null;
            Scenes = new Dictionary<string, Scene>();
        }
        public void addScene(Scene val)
        {
            Scenes.Add(val.Name, val);
        }
        public void setCurrent(Scene val)
        {
            current = val;
            UManager.Instance.currentScene = current;
            UManager.Instance.invokeChangeScene();
        }
        public void setCurrent(string name)
        {
            current = Scenes[name];
            UManager.Instance.currentScene = current;
            UManager.Instance.invokeChangeScene();
        }
    }
}
