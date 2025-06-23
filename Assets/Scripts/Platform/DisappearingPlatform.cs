using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Platform
{
    public class DisappearingPlatform : Platform
    {
        private bool _isDisappearingStarted;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
                if (!_isDisappearingStarted && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    _isDisappearingStarted = true;
                    Invoke("StartDisappearing", 1.7f);
                }
        }

        private void StartDisappearing()
        {
                gameObject.SetActive(false);
        }
    }
}