using System.Linq;
using Resources.Objects.Managers.InputManager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Resources.Objects.MainCamera
{
    public class CameraPositionController : MonoBehaviour
    {
        public float moveSpeed = 20f;
        public float rotationSpeed = 50f;
        public float zoomSpeed = 50f;
        public float zoomDistance = 10f;
        public float minZoom = 3f;
        public float maxZoom = 50f;

        private float _transformRotationX = 45f;
        private float _transformRotationY = 0f;
        private Vector3 _pivotPoint;
        private Camera _cam;

        private Vector3 _targetPivotPoint;
        private bool _isCentering = false;
        public float centerLerpSpeed = 5f;

        private void Awake()
        {
            _cam = GetComponent<Camera>();
            if (_cam == null)
            {
                enabled = false;
                return;
            }

            _pivotPoint = transform.position + transform.forward * zoomDistance;
        }

        private void Update()
        {
            HandleKeyboardMovement();
            HandleMousePan();
            HandleKeyboardRotation();
            HandleMouseRotation();
            HandleMouseZoom();
            CenterOnSelection();

            UpdateCameraPosition();
        }

        private void CenterOnSelection()
        {
            if (!GameInputManager.Instance.IsPressed("CenterOnSelection") &&
                !GameInputManager.Instance.WasPressedThisFrame("CenterOnSelection"))
                return;

            _isCentering = true;
        }

        #region MouseMovement

        private void HandleKeyboardMovement()
        {
            var direction = Vector3.zero;

            if (GameInputManager.Instance.IsPressed("CameraKeyMoveForward"))
            {
                direction += Vector3.forward;
                _isCentering = false;
            }

            if (GameInputManager.Instance.IsPressed("CameraKeyMoveBack"))
            {
                direction += Vector3.back;
                _isCentering = false;
            }

            if (GameInputManager.Instance.IsPressed("CameraKeyMoveLeft"))
            {
                direction += Vector3.left;
                _isCentering = false;
            }

            if (GameInputManager.Instance.IsPressed("CameraKeyMoveRight"))
            {
                direction += Vector3.right;
                _isCentering = false;
            }

            var move = Quaternion.Euler(0, _transformRotationY, 0) * direction;
            _pivotPoint += move * (moveSpeed * Time.deltaTime);
        }

        private void HandleMousePan()
        {
            var mouse = Mouse.current;
            var keyboard = Keyboard.current;
            if (mouse == null || keyboard == null) return;

            // SHIFT + Middle Mouse
            if (GameInputManager.Instance.AllPressed("MousePan"))
            {
                _isCentering = false;
            }
            else
            {
                return;
            }

            var delta = mouse.delta.ReadValue();
            // Направления камеры в мире
            var right = transform.right;
            var forward = Vector3.Cross(transform.right, Vector3.up).normalized;
            // Вычисляем смещение (Z не трогаем)
            var panOffset = (-right * delta.x + -forward * delta.y) * (moveSpeed * 0.25f * Time.deltaTime);
            // Принудительно оставить исходную высоту (Z)
            var originalZ = _pivotPoint.y;
            _pivotPoint += panOffset;
            _pivotPoint.y = originalZ; // Z = высота, не меняем
        }

        #endregion

        #region MouseRotation

        private void HandleKeyboardRotation()
        {
            if (GameInputManager.Instance.IsPressed("CameraKeyRotationLeft"))
                _transformRotationY -= rotationSpeed * Time.deltaTime * 2;
            if (GameInputManager.Instance.IsPressed("CameraKeyRotationRight"))
                _transformRotationY += rotationSpeed * Time.deltaTime * 2;
        }

        private void HandleMouseRotation()
        {
            var keyboard = Keyboard.current;
            if (keyboard.shiftKey.isPressed)
                return;

            if (!GameInputManager.Instance.IsPressed("CameraMouseRotationKey")) return;

            var delta = Mouse.current.delta.ReadValue();
            _transformRotationY += delta.x * rotationSpeed * Time.deltaTime;
            _transformRotationX -= delta.y * rotationSpeed * Time.deltaTime;
            _transformRotationX = Mathf.Clamp(_transformRotationX, -89f, 89f);
        }

        #endregion

        private void HandleMouseZoom()
        {
            var scrollValue = Mouse.current.scroll.ReadValue().y;
            if (!(Mathf.Abs(scrollValue) > 0.1f)) return;

            zoomDistance -= scrollValue * zoomSpeed * Time.deltaTime;
            zoomDistance = Mathf.Clamp(zoomDistance, minZoom, maxZoom);
        }

        private void UpdateCameraPosition()
        {
            if (_isCentering)
            {
                _pivotPoint = Vector3.Lerp(_pivotPoint, _targetPivotPoint, Time.deltaTime * centerLerpSpeed);

                if (Vector3.Distance(_pivotPoint, _targetPivotPoint) < 0.01f)
                {
                    _pivotPoint = _targetPivotPoint;
                    _isCentering = false;
                }
            }

            var rot = Quaternion.Euler(_transformRotationX, _transformRotationY, 0);
            var offset = rot * new Vector3(0, 0, -zoomDistance);
            transform.position = _pivotPoint + offset;
            transform.rotation = rot;
        }
    }
}