using UnityEngine;

namespace Assets.Scripts
{
    public class RandomColorGeneration : MonoBehaviour
    {
        public Color RandomColor()
        {
            return new Color(Random.value, Random.value, Random.value, 1f);
        }
    }
}

