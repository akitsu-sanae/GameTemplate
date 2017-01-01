using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTemplate.Scene
{
    class Game : asd.Scene
    {
        public Game()
        {
            var layer = new asd.Layer2D();

            var titleLabel = new asd.TextObject2D();
            titleLabel.Font = Resource.Font;
            titleLabel.Text = "ゲーム画面";

            layer.AddObject(titleLabel);

            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (Input.State(Input.Button.Button1) == asd.KeyState.Push)
                asd.Engine.ChangeScene(new Scene.Title());
        }
    }
}
