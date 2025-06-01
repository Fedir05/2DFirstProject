using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    private bool isJumping;
    [SerializeField] private float jumpForce = 5;
    
    void Update()
    {
        CalculateJump();
    }

    private void CalculateJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            isJumping = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, (ForceMode)ForceMode2D.Impulse);
        }
        
    }
}
