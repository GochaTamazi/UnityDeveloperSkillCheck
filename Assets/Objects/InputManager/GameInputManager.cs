using UnityEngine;

namespace Resources.Objects.Managers.InputManager
{
    public class GameInputManager : MonoBehaviour
    {
        public static GameInputManager Instance { get; private set; }

        public InputBindings bindings;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        public bool AllPressed(string actionName)
        {
            var b = bindings.GetBinding(actionName);
            return b != null && InputActionChecker.AllPressed(b);
        }

        public bool IsPressed(string actionName)
        {
            var b = bindings.GetBinding(actionName);
            return b != null && InputActionChecker.IsPressed(b);
        }

        public bool WasPressedThisFrame(string actionName)
        {
            var b = bindings.GetBinding(actionName);
            return b != null && InputActionChecker.WasPressedThisFrame(b);
        }

        public bool WasReleasedThisFrame(string actionName)
        {
            var b = bindings.GetBinding(actionName);
            return b != null && InputActionChecker.WasReleasedThisFrame(b);
        }
    }
}