using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts

{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementManager playerMovementManager;
        
        public float MoveDirection { get; private set; }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMovementManager.TryJump();
            }
            
            MoveDirection = Input.GetAxis("Horizontal");
        }
        
    }
}