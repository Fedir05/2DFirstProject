using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    private bool isJumping = false;
    [SerializeField] private float jumpForce = 5f;
    private bool isGrounded = false;
    [SerializeField] private float groundCheckRadius = 1.2f;
    [SerializeField] private LayerMask groundMask;

    void Update()
    {
        CalculateJump();
    }

    private void CalculateJump()
    {
        isGrounded = Physics2D.Raycast(player.position, Vector2.down, groundCheckRadius, groundMask);
        Debug.DrawRay(player.position,Vector2.down * groundCheckRadius, Color.red);
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            if (isJumping)
            {
                player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = false;
            }
        }
    }
}
