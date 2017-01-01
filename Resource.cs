using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTemplate
{
    class Resource
    {
        public static asd.Font Font { get; private set; }
        public const int FontSize = 32;

        public static void Initialize()
        {
            Font = asd.Engine.Graphics.CreateDynamicFont("", FontSize, new asd.Color(255, 255, 255), 0, new asd.Color());
        }
    }
}
