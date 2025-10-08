using UnityEngine;

namespace Tools
{
    [ExecuteInEditMode]
    public class AlignToGround : MonoBehaviour
    {
        [Tooltip("Maximum raycast distance down")]
        public float raycastDistance = 100f;
    }
}