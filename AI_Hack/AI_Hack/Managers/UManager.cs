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
using AI_Hack.Core;
using System.Reflection;

namespace AI_Hack.Managers
{
    class UManager
    {
        public Scene currentScene;
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager gxManager;
        private ContentManager cManager;
        static UManager instance;
        private SceneManager sManager;
        private bool nInit;
        private Game1 game;

        int winWidth, winHeight;

        public SpriteBatch Sprite
        {
            get { return spriteBatch; }
        }
        public GraphicsDeviceManager GXManager
        {
            get { return gxManager; }
        }
        public static UManager Instance
        {
            get
            {
                return instance;
            }
        }
        public ContentManager CManager
        {
            get { return cManager; }
        }
        public SceneManager SManager
        {
            get { return sManager; }
        }
        public int WinWidth
        {
            get { return winWidth; }
            set {
                winWidth = value;
                gxManager.PreferredBackBufferWidth = value;
                game.Graphics.PreferredBackBufferWidth = value;
                game.Graphics.ApplyChanges();
            }
        }
        public int WinHeight
        {
            get { return winHeight; }
            set
            {
                winHeight = value;
                gxManager.PreferredBackBufferHeight = value;
                game.Graphics.PreferredBackBufferHeight = value;
                game.Graphics.ApplyChanges();
            }
        }

        public UManager(Game1 g)
        {
            currentScene = null;
            game = g;
            nInit = true;
            spriteBatch = game.Sprite ;
            gxManager = game.Graphics;
            cManager = game.Content;
            winWidth = gxManager.PreferredBackBufferWidth;
            winHeight = gxManager.PreferredBackBufferHeight;
            sManager = new SceneManager();
            instance = this;
            extractScenes();
            
        }

        private void extractScenes()
        {
            var ScenesList = Assembly.GetExecutingAssembly().GetTypes().ToList().Where(t => t.Namespace == "AI_Hack.Scenes").ToList();
            
            foreach (var x in ScenesList)
            {
                var seen = Activator.CreateInstance(x,x.Name);
                sManager.addScene((Scene)seen);
            }
        }
        public void invokeChangeScene()
        {
            nInit = false;
        }
        public void init()
        {
            if (currentScene != null && !currentScene.isDone)
            {
                currentScene.init();
                currentScene.setupScene();
                nInit = true;
            }
        }
        public void input()
        {
            if (!nInit)
                this.init();
            if(currentScene != null)
                currentScene.Input();
        }
        public void update()
        {
            InputManager.Instance.Update();
            if (currentScene != null)
                currentScene.Update();
        }
        public void draw()
        {
            if (currentScene != null)
                currentScene.Draw();
        }
    }
}
