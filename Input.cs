using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTemplate
{
    class Input
    {
        public enum Button
        {
            Up,
            Down,
            Left,
            Right,

            Button1,
            Button2,
            Button3,
            Button4
        }

        private static asd.Keys Convert(Button button)
        {
            switch (button)
            {
                case Button.Left:
                    return asd.Keys.Left;
                case Button.Right:
                    return asd.Keys.Right;
                case Button.Up:
                    return asd.Keys.Up;
                case Button.Down:
                    return asd.Keys.Down;
                case Button.Button1:
                    return asd.Keys.Z;
                case Button.Button2:
                    return asd.Keys.X;
                case Button.Button3:
                    return asd.Keys.C;
                case Button.Button4:
                    return asd.Keys.V;
                default:
                    throw new Exception("invalid button: " + button.ToString());
            }
        }
        private static asd.KeyState Convert(asd.JoystickButtonState state)
        {
            switch (state)
            {
                case asd.JoystickButtonState.Free:
                    return asd.KeyState.Free;
                case asd.JoystickButtonState.Hold:
                    return asd.KeyState.Hold;
                case asd.JoystickButtonState.Push:
                    return asd.KeyState.Push;
                case asd.JoystickButtonState.Release:
                    return asd.KeyState.Release;
                default:
                    throw new Exception("invalid button state: " + state.ToString());
            }
        }

        public static asd.KeyState State(Button button)
        {
            if (asd.Engine.JoystickContainer.GetIsPresentAt(0)) // joustick
            {
                var stick = asd.Engine.JoystickContainer.GetJoystickAt(0);
                switch (button)
                {
                    case Button.Up:
                        if (stick.GetAxisState(1) < -0.5)
                            return asd.KeyState.Hold;
                        else
                            return asd.KeyState.Free;
                    case Button.Down:
                        if (stick.GetAxisState(1) > 0.5)
                            return asd.KeyState.Hold;
                        else
                            return asd.KeyState.Free;
                    case Button.Left:
                        if (stick.GetAxisState(0) < -0.5)
                            return asd.KeyState.Hold;
                        else
                            return asd.KeyState.Free;
                    case Button.Right:
                        if (stick.GetAxisState(0) > 0.5)
                            return asd.KeyState.Hold;
                        else
                            return asd.KeyState.Free;
                    case Button.Button1:
                        return Convert(stick.GetButtonState(0));
                    case Button.Button2:
                        return Convert(stick.GetButtonState(1));
                    case Button.Button3:
                        return Convert(stick.GetButtonState(2));
                    case Button.Button4:
                        return Convert(stick.GetButtonState(3));
                    default:
                        throw new Exception("invalid button: " + button.ToString());
                }
            }
            else // keyboard
            {
                return asd.Engine.Keyboard.GetKeyState(Convert(button));
            }
        }
    }
}
