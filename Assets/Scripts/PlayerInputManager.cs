using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts

{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementManager playerMovementManager;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMovementManager.TryJump();
            }
        }
        
    }
}