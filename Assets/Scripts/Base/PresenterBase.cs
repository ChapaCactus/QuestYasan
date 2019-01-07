using UnityEngine;

namespace CCG
{
    public class PresenterBase : MonoBehaviour
    {
        protected bool _isInitialized = false;

        public virtual void Initialize()
        {
            _isInitialized = true;
        }
    }

}