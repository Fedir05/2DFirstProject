using UnityEngine;

namespace Assets.Scripts
{
    public class MovementRightOrLeft : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D player;
        [SerializeField] private float moveSpeed = 2;

        private float _moveDirection;
        private Vector3 _lookRight;
        private Vector3 _lookLeft;

        void Start()
        {
            _lookRight = player.transform.localScale;
            _lookLeft = new Vector3(-player.transform.localScale.x, player.transform.localScale.y,
                player.transform.localScale.z);
        }

        private void CalculateSpeed()
        {
            _moveDirection = Input.GetAxis("Horizontal");

            if (_moveDirection < 0)
            {
                player.transform.localScale = _lookLeft;
            }
            else
            {
                player.transform.localScale = _lookRight;
            }
        }

        void FixedUpdate()
        {
            CalculateSpeed();
            player.linearVelocity = new Vector2(_moveDirection * moveSpeed, player.linearVelocity.y);
        }
    }
}
