using UnityEngine;

namespace Assets.Scripts

{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementManager playerMovementManager;
        
        void FixedUpdate()
        {
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMovementManager.TryJump();
            }
        }
        
    }
}