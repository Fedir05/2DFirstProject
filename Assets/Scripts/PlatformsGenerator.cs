using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlatformsGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private Platform _platformPrefab;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private float _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;
        
        private Queue<Platform> _spawnedPlatforms;


        private float _lastPlatformsSpawnedOnPlayerPosition;
        private float _lastPlatformsDeletedOnPlayerPosition;

        private void Awake()
        {
            _spawnedPlatforms = new Queue<Platform>();
            
            _lastPlatformsDeletedOnPlayerPosition = _lastPlatformsSpawnedOnPlayerPosition = _target.position.y;

            for (int i = 0; i < _stepsCountToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }
        
        void Update()
        {
            if(_target.position.y - _lastPlatformsSpawnedOnPlayerPosition > _stepHeight)
            {
                SpawnPlatform(_stepsCountToSpawn);
                _lastPlatformsSpawnedOnPlayerPosition += _stepHeight;
            }

            if (_target.position.y - _lastPlatformsDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete)
            {
                var _platformToDelete = _spawnedPlatforms.Dequeue();

                if (_platformToDelete && _platformToDelete.gameObject)
                {
                    Destroy(_platformToDelete.gameObject);
                }
                
                _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
            }

        }

        private void SpawnPlatform(int stepCount)
        {
            var platformPositionX = Random.Range(_bounds.x, _bounds.y);
            var platformPositionY = _target.position.y + stepCount * _stepHeight;
            
            var platformPosition = new Vector3(platformPositionX, platformPositionY, 0);
            
            var spawnedPlatform = Instantiate(_platformPrefab, platformPosition, Quaternion.identity, this.transform);
            
            spawnedPlatform.Init(_target);
            _spawnedPlatforms.Enqueue(spawnedPlatform);
        }
    }
}