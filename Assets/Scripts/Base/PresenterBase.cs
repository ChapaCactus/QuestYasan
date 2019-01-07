using UnityEngine;

namespace CCG
{
    public abstract class PresenterBase : MonoBehaviour
    {
        protected bool _isInitialized = false;

        public virtual void Initialize()
        {
            _isInitialized = true;
        }

        protected abstract void BindModelEvents();
        protected abstract void BindViewEvents();
    }

}