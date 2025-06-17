using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovementManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D player;
        
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float groundCheckRadius = 1.2f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private RandomColorGeneration randomColorGeneration;
        private bool isGrounded = false;
        
        
        [SerializeField] private PlayerInputManager _inputManager;
        [SerializeField] private float moveSpeed = 2f;
        private float _moveDirection;
        private Vector3 _lookRight;
        private Vector3 _lookLeft;
        
        void Start()
        {
            _lookRight = player.transform.localScale;
            _lookLeft = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
        }


        void FixedUpdate()
        {
            Debug.DrawRay(player.position,Vector2.down * groundCheckRadius, Color.red);
            
            
            _moveDirection = _inputManager.MoveDirection;
            if (_moveDirection < 0)
            {
                player.transform.localScale = _lookLeft;
            }
            else if (_moveDirection > 0)
            {
                player.transform.localScale = _lookRight;
            }
            player.linearVelocity = new Vector2(_moveDirection * moveSpeed, player.linearVelocity.y);
        }
        
        public void TryJump()
        {
            isGrounded = Physics2D.Raycast(player.position, Vector2.down, groundCheckRadius, groundMask);
            
            if (isGrounded)
            {
                    player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    spriteRenderer.color = randomColorGeneration.RandomColor();
            }
        }
    }
}