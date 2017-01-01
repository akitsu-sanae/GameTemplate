using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTemplate
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var option = new asd.EngineOption();
            var isFullscreen = System.Windows.Forms.MessageBox.Show("ふるすくりーんにする？", Config.Window.Title, System.Windows.Forms.MessageBoxButtons.YesNo);
            option.IsFullScreen = isFullscreen == System.Windows.Forms.DialogResult.Yes;
            asd.Engine.Initialize(Config.Window.Title, Config.Window.Width, Config.Window.Height, option);
            Resource.Initialize();

            asd.Engine.ChangeScene(new Scene.Title());

            while (asd.Engine.DoEvents())
            {
                if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Escape) == asd.KeyState.Push)
                    break;
                if (Config.isQuit)
                    break;

                asd.Engine.Update();
            }

            asd.Engine.Terminate();
        }
    }
}
