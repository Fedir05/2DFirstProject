using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Player

{
    public class PlayerInputManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementManager playerMovementManager;
        [SerializeField] private RandomColorGeneration spritePainter;
        
        public float MoveDirection { get; private set; }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerMovementManager.TryJump();
                spritePainter.ChangeSpriteColorToRandom();
            }
            
            MoveDirection = Input.GetAxis("Horizontal");
        }
        
    }
}