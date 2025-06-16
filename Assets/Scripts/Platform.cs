using UnityEngine;

namespace Assets.Scripts 
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] protected Transform _target;
        [SerializeField] protected GameObject _collision;

        protected bool _isInitiated;

        public void Init(Transform target)
        {
            _target = target;
            
            _isInitiated = true;
        }

        void Update()
        {
            if (_isInitiated)
            {
                OnUpdatePlatform();
            }
        }

        protected virtual void OnUpdatePlatform()
        {
            if (_target.transform.position.y > transform.position.y)
            {
                _collision.SetActive(true);
            }
            else
            {
                _collision.SetActive(false);
            }
                
        }
    }
}