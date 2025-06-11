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
        
        public void TryJump()
        {
            isGrounded = Physics2D.Raycast(player.position, Vector2.down, groundCheckRadius, groundMask);
            Debug.DrawRay(player.position,Vector2.down * groundCheckRadius, Color.red);
            
            if (isGrounded)
            {
                    player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    spriteRenderer.color = randomColorGeneration.RandomColor();
            }
        }
    }
}