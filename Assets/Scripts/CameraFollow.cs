using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float speed = 1;

        [Space] private bool _followByX = true;
        private bool _followByY = true;
        private bool _followByZ = true;

        void Update()
        {
            var targetPosition = new Vector3(
                _followByX ? playerTransform.position.x : transform.position.x,
                _followByY ? playerTransform.position.y : transform.position.y,
                _followByZ ? playerTransform.position.z : transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
