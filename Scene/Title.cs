using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTemplate.Scene
{
    class Title : asd.Scene
    {
        public Title()
        {
            var layer = new asd.Layer2D();

            var titleLabel = new asd.TextObject2D();
            titleLabel.Font = Resource.Font;
            titleLabel.Text = Config.Window.Title;
            layer.AddObject(titleLabel);

            gameStartLabel.Font = Resource.Font;
            gameStartLabel.Text = "Game Start";
            gameStartLabel.Position = new asd.Vector2DF(320, 320);
            layer.AddObject(gameStartLabel);

            quitLabel.Font = Resource.Font;
            quitLabel.Text = "Quit";
            quitLabel.Position = new asd.Vector2DF(320, 320 + 32);
            layer.AddObject(quitLabel);

            cursorLabel.Font = Resource.Font;
            cursorLabel.Text = ">";
            cursorLabel.Position = gameStartLabel.Position - new asd.Vector2DF(Resource.FontSize, 0);
            layer.AddObject(cursorLabel);

            AddLayer(layer);
        }

        protected override void OnUpdated()
        {
            if (Input.State(Input.Button.Down) == asd.KeyState.Push)
            {
                cursor = Cursor.Quit;
                cursorLabel.Position = quitLabel.Position - new asd.Vector2DF(Resource.FontSize, 0);
            }

            if (Input.State(Input.Button.Up) == asd.KeyState.Push)
            {
                cursor = Cursor.GameStart;
                cursorLabel.Position = gameStartLabel.Position - new asd.Vector2DF(Resource.FontSize, 0);
            }

            if (Input.State(Input.Button.Button1) == asd.KeyState.Push)
            {
                switch (cursor)
                {
                    case Cursor.GameStart:
                        asd.Engine.ChangeScene(new Scene.Game());
                        break;
                    case Cursor.Quit:
                        Config.isQuit = true;
                        break;
                }
            }
        }

        enum Cursor
        {
            GameStart,
            Quit
        }

        Cursor cursor = Cursor.GameStart;
        private asd.TextObject2D gameStartLabel = new asd.TextObject2D();
        private asd.TextObject2D quitLabel = new asd.TextObject2D();
        private asd.TextObject2D cursorLabel = new asd.TextObject2D();
    }
}
