using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Resources.Objects.Managers.InputManager
{
    public static class InputActionChecker
    {
        public static bool AllPressed(InputBindings.Binding binding)
        {
            foreach (var key in binding.keys)
            {
                if (Keyboard.current[key]?.isPressed != true)
                    return false;
            }

            foreach (MouseButton btn in binding.mouseButtons)
            {
                if (GetMouseButton(btn)?.isPressed != true)
                    return false;
            }

            return true;
        }

        public static bool IsPressed(InputBindings.Binding binding)
        {
            foreach (var key in binding.keys)
            {
                if (Keyboard.current[key]?.isPressed == true)
                    return true;
            }

            foreach (MouseButton btn in binding.mouseButtons)
            {
                if (GetMouseButton(btn)?.isPressed == true)
                    return true;
            }

            return false;
        }

        public static bool WasPressedThisFrame(InputBindings.Binding binding)
        {
            foreach (var key in binding.keys)
            {
                if (Keyboard.current[key]?.wasPressedThisFrame == true)
                    return true;
            }

            foreach (MouseButton btn in binding.mouseButtons)
            {
                if (GetMouseButton(btn)?.wasPressedThisFrame == true)
                    return true;
            }

            return false;
        }

        public static bool WasReleasedThisFrame(InputBindings.Binding binding)
        {
            foreach (var key in binding.keys)
            {
                if (Keyboard.current[key]?.wasReleasedThisFrame == true)
                    return true;
            }

            foreach (MouseButton btn in binding.mouseButtons)
            {
                if (GetMouseButton(btn)?.wasReleasedThisFrame == true)
                    return true;
            }

            return false;
        }

        private static ButtonControl GetMouseButton(MouseButton btn)
        {
            var mouse = Mouse.current;
            return btn switch
            {
                MouseButton.Left => mouse.leftButton,
                MouseButton.Right => mouse.rightButton,
                MouseButton.Middle => mouse.middleButton,
                _ => null,
            };
        }

        public enum MouseButton
        {
            Left,
            Right,
            Middle
        }
    }
}