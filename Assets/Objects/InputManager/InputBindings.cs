using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace Resources.Objects.Managers.InputManager
{
    [CreateAssetMenu(fileName = "InputBindings", menuName = "Custom/Input Bindings")]
    public class InputBindings : ScriptableObject
    {
        [System.Serializable]
        public class Binding
        {
            public string actionName; // например "MoveForward"
            public List<Key> keys = new(); // можно несколько клавиш
            public List<MouseButton> mouseButtons = new(); // опционально мышь
        }

        public List<Binding> bindings = new();

        public Binding GetBinding(string actionName)
        {
            return bindings.Find(b => b.actionName == actionName);
        }
    }
}