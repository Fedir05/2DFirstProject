using UnityEngine;

namespace Scripts.Player
{
    public class RandomColorGeneration : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public void ChangeSpriteColorToRandom()
        {
            var randomColor = new Color(Random.value, Random.value, Random.value, 1f);
            _spriteRenderer.color = randomColor;
        }
    }
}

