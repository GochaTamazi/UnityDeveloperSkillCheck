using System.Collections.Generic;
using UnityEngine;

namespace Objects.ObjectSpawner
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabs = new();

        [SerializeField] private Transform spawnPoint;

        [SerializeField] private float spawnInterval = 2f;

        [SerializeField] private float spawnRadius = 0f;

        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= spawnInterval)
            {
                SpawnRandomObject();
                _timer = 0f;
            }
        }

        private void SpawnRandomObject()
        {
            if (prefabs.Count == 0 || spawnPoint == null)
                return;

            var prefab = prefabs[Random.Range(0, prefabs.Count)];

            Vector3 spawnPosition = spawnPoint.position;
            if (spawnRadius > 0f)
            {
                Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
                spawnPosition += new Vector3(randomOffset.x, 0f, randomOffset.y);
            }

            Instantiate(prefab, spawnPosition, spawnPoint.rotation);
        }

        private void OnDrawGizmosSelected()
        {
            if (spawnPoint != null && spawnRadius > 0f)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(spawnPoint.position, spawnRadius);
            }
        }
    }
}