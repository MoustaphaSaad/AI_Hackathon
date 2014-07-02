using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI_Hack.Loader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AI_Hack.Core;
namespace AI_Hack.Core
{
    public abstract partial class Observer
    {
        public partial class GameScene:Scene, ISubject
        {
            protected EnvironmentX Tileset;
            protected List<Observer> observers;
            public GameScene(string n)
                : base(n)
            {
                Tileset = null;
                observers = new List<Observer>();
            }

            public void Attach(Observer obj)
            {
                observers.Add(obj);
            }
            public void Detach(Observer obj)
            {
                observers.Remove(obj);
            }
            public void Notify(object msg)
            {
                foreach (Observer obj in observers)
                    obj.Update(msg);
            }
            public override void Update()
            {
                Notify(getMap());
                base.Update();
            }

            public TileX[,] getMap()
            {
                if (Tileset == null)
                    return null;
                else
                {
                    TileX[,] res = new TileX[Tileset.TilesSize.Width, Tileset.TilesSize.Height];
                    for (int i = 0; i < Tileset.TilesSize.Width; i++)
                        for (int j = 0; j < Tileset.TilesSize.Height; j++)
                            res[i, j] = new TileX();
                    foreach (GameObject obj in childList)
                    {
                        Vector2 po = Tileset.PositionToTileIndex(obj.transform.position.X, obj.transform.position.Y);
                        res[(int)po.X, (int)po.Y] = new TileX(1, TileState.Occupied);
                    }
                    return res;
                }
            }
        }
    }
}
