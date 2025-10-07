using UnityEngine;

namespace Objects.AutoLookAt
{
    public class AutoLookAt : MonoBehaviour
    {
        [SerializeField] private Transform target; // Target we are looking at
        [SerializeField] private float rotationSpeed = 5f; // Turning speed
        [SerializeField] private bool lockYAxis = false; // Limit rotation along the Y axis

        private void Update()
        {
            if (target == null)
                return;

            // Direction to target
            Vector3 direction = target.position - transform.position;

            // If necessary, lock rotation along the Y axis
            if (lockYAxis)
                direction.y = 0f;

            // Check that the direction is not zero
            if (direction.sqrMagnitude < 0.001f)
                return;

            // Calculate the desired orientation
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);

            // Smooth rotation
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}