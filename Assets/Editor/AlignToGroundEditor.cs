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
            Renderer renderer = objTransform.GetComponentInChildren<Renderer>();

            if (renderer == null)
            {
                Debug.LogWarning($"AlignToGround: {objTransform.name} has no Renderer to calculate bounds.");
                return;
            }

            // Определяем нижнюю точку объекта
            Bounds bounds = renderer.bounds;
            Vector3 bottomPoint = new Vector3(bounds.center.x, bounds.min.y, bounds.center.z);

            // Пускаем Raycast немного выше, чтобы не попасть в сам объект
            Vector3 rayOrigin = bottomPoint + Vector3.up * 0.5f;

            if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, aligner.raycastDistance))
            {
                Undo.RecordObject(objTransform, "Align to Ground");

                // Смещение от pivot до нижней точки
                float bottomOffset = bottomPoint.y - objTransform.position.y;

                // Выставляем объект так, чтобы низ модели касался земли
                objTransform.position = new Vector3(
                    objTransform.position.x,
                    hit.point.y - bottomOffset,
                    objTransform.position.z
                );

                // 💡 Бонус: выравнивание под наклон поверхности
                objTransform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal) * objTransform.rotation;
            }
            else
            {
                Debug.LogWarning($"AlignToGround: surface under {objTransform.name} not found.");
            }
        }
    }
}
