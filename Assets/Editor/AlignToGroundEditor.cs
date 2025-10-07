using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
    [CustomEditor(typeof(AlignToGround))]
    public class AlignToGroundEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            AlignToGround aligner = (AlignToGround)target;

            if (GUILayout.Button("Align to Ground"))
            {
                AlignObjectToGround(aligner);
            }
        }

        private void AlignObjectToGround(AlignToGround aligner)
        {
            Transform objTransform = aligner.transform;

            if (Physics.Raycast(objTransform.position + Vector3.up * 0.5f, Vector3.down, out RaycastHit hit,
                    aligner.raycastDistance))
            {
                Undo.RecordObject(objTransform, "Align to Ground");
                objTransform.position = hit.point;

                // 💡 Bonus - the ability to delete an element
                objTransform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else
            {
                Debug.LogWarning($"AlignToGround: surface under {objTransform.name} not found.");
            }
        }
    }
}