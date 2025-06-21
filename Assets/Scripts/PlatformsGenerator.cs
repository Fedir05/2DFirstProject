using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlatformsGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private List<Platform> _platformPrefabVariants;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private float _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;

        private Queue<List<Platform>> _spawnedPlatforms;

        private float _lastPlatformsSpawnedOnPlayerPosition;
        private float _lastPlatformsDeletedOnPlayerPosition;

        private void Awake()
        {
            _spawnedPlatforms = new Queue<List<Platform>>();

            _lastPlatformsDeletedOnPlayerPosition = _lastPlatformsSpawnedOnPlayerPosition = _target.position.y;

            for (int i = 0; i < _stepsCountToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }

        private void Update()
        {
            if (_target.position.y - _lastPlatformsSpawnedOnPlayerPosition > _stepHeight)
            {
                SpawnPlatform(_stepsCountToSpawn);
                _lastPlatformsSpawnedOnPlayerPosition += _stepHeight;
            }

            if (_target.position.y - _lastPlatformsDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete)
            {
                var platformGroupToDelete = _spawnedPlatforms.Dequeue();

                foreach (var platform in platformGroupToDelete)
                {
                    if (platform != null && platform.gameObject != null)
                    {
                        Destroy(platform.gameObject);
                    }
                }

                _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
            }
        }

        private void SpawnPlatform(int stepCount)
        {
            var platformPositionY = _target.position.y + stepCount * _stepHeight;

            var platformsToSpawnCount = Random.Range(1, 3); 
            var platformGroup = new List<Platform>();

            for (int i = 0; i < platformsToSpawnCount; i++)
            {
                var platformPositionX = Random.Range(_bounds.x, _bounds.y);
                var platformPosition = new Vector3(platformPositionX, platformPositionY, 0);

                var randomPlatform = _platformPrefabVariants[Random.Range(0, _platformPrefabVariants.Count)];

                var spawnedPlatform = Instantiate(randomPlatform, platformPosition, Quaternion.identity, this.transform);
                spawnedPlatform.Init(_target);

                platformGroup.Add(spawnedPlatform);
            }

            _spawnedPlatforms.Enqueue(platformGroup);
        }
    }
}
