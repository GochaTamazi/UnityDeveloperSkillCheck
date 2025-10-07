using UnityEngine;

namespace Tools
{
    [ExecuteInEditMode]
    public class AlignToGround : MonoBehaviour
    {
        [Tooltip("Maximum beam length down")]
        public float raycastDistance = 100f;
    }
}